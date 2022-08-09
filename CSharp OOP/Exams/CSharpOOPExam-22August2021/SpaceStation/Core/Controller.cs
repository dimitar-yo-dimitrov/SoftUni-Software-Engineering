using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Factories;
using SpaceStation.Factories.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;

        private readonly IAstronautFactory astronautFactory;
        private readonly IPlanetFactory planetFactory;

        private readonly IMission mission;

        private int exploredPlanetsCount;

        public Controller(
            AstronautRepository astronautRepository, 
            PlanetRepository planetRepository, 
            IAstronautFactory astronautFactory, 
            IPlanetFactory planetFactory, 
            IMission mission)
        {
            this.astronautRepository = astronautRepository;
            this.planetRepository = planetRepository;

            this.astronautFactory = astronautFactory;
            this.planetFactory = planetFactory;
            this.mission = mission;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = astronautFactory
                .CreateAstronaut(type, astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);

            return string.Format(
                OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = planetFactory
                .CreatePlanet(planetName, items);

            this.planetRepository.Add(planet);

            return string.Format(
                OutputMessages.PlanetAdded, planetName, items);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planetRepository.FindByName(planetName);

            var astronauts = astronautRepository.Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, astronauts);
            this.exploredPlanetsCount++;

            var deadAstronauts = astronauts
                .Count(x => !x.CanBreath);

            return string.Format(
                OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{exploredPlanetsCount} planets were explored!");
            report.AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            {
                report.AppendLine($"{astronaut}");
            }

            return report.ToString().TrimEnd();
        }
    }
}
