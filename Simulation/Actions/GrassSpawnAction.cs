using Simulation.Entities;

namespace Simulation.Actions
{
    internal class GrassSpawnAction : PlantSpawnAction
    {
        private static readonly string GrassEmoji = "\uD83C\uDF3F";

        internal override void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities)
        {
            Random random = new Random();
            var row = random.Next(SimulationManager.WorldRows);
            var column = random.Next(SimulationManager.WorldColumns);

            Coordinates spawnCoordinates = new Coordinates(row, column);
            Grass grass = new Grass(spawnCoordinates, GrassEmoji);
            map[spawnCoordinates] = grass;
            generatedEntities.Add(grass);
        }
    }
}
