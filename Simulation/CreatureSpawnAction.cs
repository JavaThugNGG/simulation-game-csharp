namespace Simulation
{
    internal abstract class CreatureSpawnAction
    {
        internal abstract void Perform(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities);
    }
}
