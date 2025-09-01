namespace Simulation
{
    internal class HerbivoreSpawnAction
    {
        private static readonly string _herbivoreEmoji = "\uD83D\uDC30";

        internal void Perform(IDictionary<Coordinates, Entity> map, List<Entity> generatedEntities)
        {
            Random random = new Random();
            int row = random.Next(SimulationManager.WorldRows);
            int column = random.Next(SimulationManager.WorldColumns);

            Coordinates spawnCoordinates = new Coordinates(row, column);
            Herbivore herbivore = new Herbivore(spawnCoordinates, _herbivoreEmoji);
            map[spawnCoordinates] = herbivore;
            generatedEntities.Add(herbivore);
        }
    }
}
