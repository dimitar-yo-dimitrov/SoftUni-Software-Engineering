using SpaceStation.Factories;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Repositories;

namespace SpaceStation
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();

            var astronautRepository = new AstronautRepository();
            var planetRepository = new PlanetRepository();
            var astronautFactory = new AstronautFactory();
            var planetFactory = new PlanetFactory();
            var mission = new Mission();

            IController controller = new Controller(
                astronautRepository,
                planetRepository,
                astronautFactory,
                planetFactory,
                mission);

            IEngine engine = new Engine(
                writer,
                reader,
                controller);
            engine.Run();
        }
    }
}