namespace Simulation
{
    internal class MoveCreaturesAction
    {
        private static readonly int PredatorMoveSteps = 2;

        internal void Perform(IList<Entity> generatedEntities, PathFinder pathFinder)
        {
            foreach (Entity entity in generatedEntities)
            {
                if (entity is Creature creature)
                {
                    HandleCreatureMove(pathFinder, creature);
                }
            }
        }

        private void HandleCreatureMove(PathFinder pathFinder, Creature creature) 
        {
            List<Coordinates> path = pathFinder.FindPathToVictim(creature);  //нормальный путь возвращается

            if (path.Count == 0)
            {
                return;
            }

            if (creature is Predator)
            {
                MovePredator(creature, path);    //видимо эти методы фонят
            }
            else if (creature is Herbivore)
            {
                MoveHerbivore(creature, path);
            }
        }

        private void MovePredator(Creature predator, IList<Coordinates> path)
        {
            for (int i = 0; i < PredatorMoveSteps; i++)
            {
                if (path.Count == 0)
                {
                    break;
                }
                Coordinates newCoordinates = path.First();
                path.RemoveAt(0);
                predator.MakeMove(newCoordinates);
            }
        }

        private void MoveHerbivore(Creature herbivore, IList<Coordinates> path)
        {
            Coordinates newCoordinates = path.First();
            path.RemoveAt(0);
            herbivore.MakeMove(newCoordinates);
        }
    } 
}
