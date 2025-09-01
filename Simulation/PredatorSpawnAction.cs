namespace Simulation
{
    internal class PredatorSpawnAction : CreatureSpawnAction
    {
        private static readonly string PredatorEmoji = "\uD83D\uDC3A";

        internal override void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities)
        {
            Random random = new Random();
            int row = random.Next(SimulationManager.WorldRows);
            int column = random.Next(SimulationManager.WorldColumns);
            Coordinates spawnCoordinates = new Coordinates(row, column);
            Predator predator = new Predator(spawnCoordinates, PredatorEmoji);
            map[spawnCoordinates] = predator;
            generatedEntities.Add(predator);
        }
    }
}
