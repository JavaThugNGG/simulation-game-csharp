using Simulation.Entities;

namespace Simulation.Actions
{
    internal class TreeSpawnAction : PlantSpawnAction
    {
        private static readonly string TreeEmoji = "\uD83C\uDF33";

        internal override void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities)
        {
            Random random = new Random();
            var row = random.Next(SimulationManager.WorldRows);
            var column = random.Next(SimulationManager.WorldColumns);
            Coordinates spawnCoordinates = new Coordinates(row, column);
            Tree tree = new Tree(spawnCoordinates, TreeEmoji);

            map[spawnCoordinates] = tree;
            generatedEntities.Add(tree);
        }
    }
}
