namespace Simulation
{
    internal class TreeSpawnAction : PlantSpawnAction
    {
        private static readonly string TreeEmoji = "\uD83C\uDF33";

        internal override void Perform(IDictionary<Coordinates, Entity> map, List<Entity> generatedEntities)
        {
            Random random = new Random();
            int row = random.Next(SimulationManager.WorldRows);
            int column = random.Next(SimulationManager.WorldColumns);
            Coordinates spawnCoordinates = new Coordinates(row, column);
            Tree tree = new Tree(spawnCoordinates, TreeEmoji);

            map[spawnCoordinates] = tree;
            generatedEntities.Add(tree);
        }
    }
}
