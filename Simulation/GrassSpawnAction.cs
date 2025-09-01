namespace Simulation
{
    internal class GrassSpawnAction : CreatureSpawnAction
    {
        private static readonly string GrassEmoji = "\uD83C\uDF3F";

        internal override void Perform(IDictionary<Coordinates, Entity> map, List<Entity> generatedEntities)
        {
            Random random = new Random();
            int row = random.Next(SimulationManager.WorldRows);
            int column = random.Next(SimulationManager.WorldColumns);

            Coordinates spawnCoordinates = new Coordinates(row, column);
            Grass grass = new Grass(spawnCoordinates, GrassEmoji);
            map[spawnCoordinates] = grass;
            generatedEntities.Add(grass);
        }
    }
}
