using Simulation.Entities;

namespace Simulation.Actions
{
    internal abstract class PlantSpawnAction
    {
        internal abstract void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities);
    }
}
