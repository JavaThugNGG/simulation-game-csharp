using Simulation.Entities;

namespace Simulation
{
    internal class MapController
    {
        private readonly IDictionary<Coordinates, Entity> _map;

        internal MapController(IDictionary<Coordinates, Entity> map, IList<Entity> generatedEntities)
        {
            _map = map;
            FillMap(generatedEntities);
        }

        private void FillMap(IList<Entity> generatedEntities)
        {
            foreach (Entity entity in generatedEntities)
            {
                Coordinates entityCoordinates = entity.Coordinates;
                _map[entityCoordinates] = entity;

                if (entity is Creature creature)
                {
                    creature.Moved += OnCreatureMoved;
                }
            }
        }
        private void OnCreatureMoved(object sender, Coordinates oldCoordinates, Coordinates newCoordinates)
        {
            _map[newCoordinates] = (Entity)sender;
            _map.Remove(oldCoordinates);
        }
    }
}
