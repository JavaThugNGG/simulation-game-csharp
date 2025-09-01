namespace Simulation
{
    internal class SimulationManager//напишешь что весь жизненный цикл хуйнул в коммит
    {
        public static readonly int WorldRows = 10;
        public static readonly int WorldColumns = 20;

        private readonly IDictionary<Coordinates, Entity> _map = new Dictionary<Coordinates, Entity>();
        private readonly PathFinder _pathFinder;
        private readonly IList<Entity> _generatedEntities = new List<Entity>();
        private readonly WorldPrinter _worldPrinter = new WorldPrinter();

        private readonly IList<CreatureSpawnAction> _creatureInitActions = new List<CreatureSpawnAction>();
        private readonly IList<PlantSpawnAction> _plantInitActions = new List<PlantSpawnAction>();
        private readonly IList<MoveCreaturesAction> _turActions = new List<MoveCreaturesAction>();

        private volatile bool _isEnd = false;

        internal SimulationManager()
        {
            _pathFinder = new PathFinder(_map);
        }

        internal bool IsEnd => _isEnd;

        internal void InitializeSimulation()
        {
            _creatureInitActions.Add(new HerbivoreSpawnAction());

        }

        private void StartSimulation()
        {
            if (!IsEnd)
            {
                _worldPrinter.Print(_map);
                MoveCreations();
                _isEnd = IsAllHerbivoresDead();
            }
        }



    }
}
