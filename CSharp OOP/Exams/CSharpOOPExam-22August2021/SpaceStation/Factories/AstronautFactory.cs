using SpaceStation.Factories.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Factories
{
    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }

            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }

            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }

            return astronaut;
        }
    }
}
