namespace Simulation
{
    internal class SimulationManager
    {
        public static readonly int WorldRows = 10;
        public static readonly int WorldColumns = 20;

        private readonly IDictionary<Coordinates, Entity> _map = new Dictionary<Coordinates, Entity>();
        private readonly PathFinder _pathFinder;
        private readonly IList<Entity> _generatedEntities = new List<Entity>();
        private readonly WorldPrinter _worldPrinter = new WorldPrinter();

        private readonly IList<CreatureSpawnAction> _creatureInitActions = new List<CreatureSpawnAction>();
        private readonly IList<PlantSpawnAction> _plantInitActions = new List<PlantSpawnAction>();
        private readonly IList<MoveCreaturesAction> _turnActions = new List<MoveCreaturesAction>();

        private volatile bool _isEnd = false;

        internal SimulationManager()
        {
            _pathFinder = new PathFinder(_map);
        }

        internal bool IsEnd => _isEnd;

        internal void InitializeSimulation()
        {
            _creatureInitActions.Add(new HerbivoreSpawnAction());
            _creatureInitActions.Add(new PredatorSpawnAction());
            _plantInitActions.Add(new GrassSpawnAction());
            _plantInitActions.Add(new TreeSpawnAction());
            _turnActions.Add(new MoveCreaturesAction());

            foreach (PlantSpawnAction action in _plantInitActions)
            {
                action.Perform(_map, _generatedEntities);
            }

            foreach (CreatureSpawnAction action in _creatureInitActions)
            {
                action.Perform(_map, _generatedEntities);
            }
        }

        internal void StartSimulation()
        {
            if (!IsEnd)
            {
                _worldPrinter.Print(_map);
                MoveCreations();
                _isEnd = IsAllHerbivoresDead();
            }
        }

        private void MoveCreations()
        {
            foreach (MoveCreaturesAction action in _turnActions)
            {
                action.Perform(_generatedEntities, _pathFinder);
            }
        }

        private bool IsAllHerbivoresDead()
        {
            foreach (Entity entity in _map.Values)
            {
                if (entity is Herbivore)
                {
                    return false;
                }
            }

            return true;
        }

        internal void PrintLast()
        {
            _worldPrinter.Print(_map);
        }
    }
}
