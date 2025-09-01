namespace Simulation
{
    internal class GrassSpawnAction
    {
        private static readonly string _grassEmoji = "\uD83C\uDF3F";

        internal void Perform(IDictionary<Coordinates, Entity> map, List<Entity> generatedEntities)
        {
            Random random = new Random();
            int row = random.Next(SimulationManager.WorldRows);
            int column = random.Next(SimulationManager.WorldColumns);

            Coordinates spawnCoordinates = new Coordinates(row, column);
            Grass grass = new Grass(spawnCoordinates, _grassEmoji);
            map[spawnCoordinates] = grass;
            generatedEntities.Add(grass);
        }
    }
}
