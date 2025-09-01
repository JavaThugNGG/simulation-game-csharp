namespace Simulation
{
    internal class HerbivoreSpawnAction : CreatureSpawnAction
    {
        private static readonly string HerbivoreEmoji = "\uD83D\uDC30";

        internal override void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities)
        {
            Random random = new Random();
            int row = random.Next(SimulationManager.WorldRows);
            int column = random.Next(SimulationManager.WorldColumns);

            Coordinates spawnCoordinates = new Coordinates(row, column);
            Herbivore herbivore = new Herbivore(spawnCoordinates, HerbivoreEmoji);
            map[spawnCoordinates] = herbivore;
            generatedEntities.Add(herbivore);
        }
    }
}
