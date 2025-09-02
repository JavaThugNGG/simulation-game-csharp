using Simulation.Entities;

namespace Simulation.Actions
{
    internal class PredatorSpawnAction : CreatureSpawnAction
    {
        private static readonly string PredatorEmoji = "\uD83D\uDC3A";

        internal override void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities)
        {
            Random random = new Random();
            var row = random.Next(SimulationManager.WorldRows);
            var column = random.Next(SimulationManager.WorldColumns);
            Coordinates spawnCoordinates = new Coordinates(row, column);
            Predator predator = new Predator(spawnCoordinates, PredatorEmoji);
            map[spawnCoordinates] = predator;
            generatedEntities.Add(predator);
        }
    }
}
