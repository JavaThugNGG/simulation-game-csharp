using Simulation.Entities;

namespace Simulation
{
    internal class PathFinder
    {
        private readonly IDictionary<Coordinates, Entity> _map;
        private Coordinates _start;

        internal PathFinder(IDictionary<Coordinates, Entity> map)
        {
            _map = map;
        }

        internal List<Coordinates> FindPathToVictim(Creature creature)
        {
            _start = creature.Coordinates;

            if (creature is Predator)
            {
                return FindPathToGoal(typeof(Herbivore));
            }

            if (creature is Herbivore)
            {
                return FindPathToGoal(typeof(Grass));
            }

            return new List<Coordinates>();
        }

        private List<Coordinates> FindPathToGoal(Type goalType)
        {
            var queue = new Queue<Coordinates>();
            var cameFrom = new Dictionary<Coordinates, Coordinates>();
            var visited = new HashSet<Coordinates>();
            queue.Enqueue(_start);
            visited.Add(_start);

            while (queue.Count > 0)
            {
                Coordinates current = queue.Dequeue();

                if (IsGoalAtCoordinates(current, goalType))
                {
                    return RecoverPath(cameFrom, _start, current);
                }

                foreach (Coordinates neighbor in GetNeighborCells(current))
                {
                    if (!visited.Contains(neighbor) && IsValidMove(neighbor, goalType))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            return new List<Coordinates>();
        }

        private bool IsValidMove(Coordinates neighbor, Type goalType)
        {
            if (_map.TryGetValue(neighbor, out Entity? entity))
            {
                if (goalType == typeof(Herbivore))
                {
                    return !(entity is Predator || entity is Tree || entity is Grass);
                }

                if (goalType == typeof(Grass))
                {
                    return !(entity is Predator || entity is Tree || entity is Herbivore);
                }
               
                Console.WriteLine($"При определении существа в методе {nameof(IsValidMove)} произошла ошибка!");
                return false;
               
            }
            else
            {
                Console.WriteLine($"При вытаскивании из мапы по индексу {neighbor} в методе {nameof(IsValidMove)} произошла ошибка! Нет такого ключа.");//это не ошибка
                return true;
            }
        }

        private bool IsGoalAtCoordinates(Coordinates current, Type goalType)
        {
            if (_map.TryGetValue(current, out Entity? currentEntity))
            {
                return goalType.IsInstanceOfType(currentEntity);
            }
            
            Console.WriteLine($"При вытаскивании из мапы по индексу {current} в методе {nameof(IsGoalAtCoordinates)} произошла ошибка! Нет такого ключа.");
            return false;
        }

        private List<Coordinates> GetNeighborCells(Coordinates coordinates)
        {
            var neighbors = new List<Coordinates>();
            int row = coordinates.Row;
            int column = coordinates.Column;

            int maxRowIndex = SimulationManager.WorldRows - 1;
            int maxColumnIndex = SimulationManager.WorldColumns - 1;

            if (row > 0)
            {
                neighbors.Add(new Coordinates(row - 1, column));
            }
            if (row < maxRowIndex)
            {
                neighbors.Add(new Coordinates(row + 1, column));
            }
            if (column > 0)
            {
                neighbors.Add(new Coordinates(row, column - 1));
            }
            if (column < maxColumnIndex)
            {
                neighbors.Add(new Coordinates(row, column + 1));
            }

            return neighbors;
        }

        private List<Coordinates> RecoverPath(IDictionary<Coordinates, Coordinates> cameFrom, Coordinates start, Coordinates goal)
        {
            var path = new List<Coordinates>();
            Coordinates current = goal;

            while (!current.Equals(start))
            {
                path.Add(current);

                if (cameFrom.TryGetValue(current, out Coordinates? valueFromDictionary))
                {
                    current = valueFromDictionary;
                }
        
            }
            path.Reverse();
            Console.WriteLine("Путь до цели:");

            foreach (var coord in path)
            {
                Console.WriteLine(coord);
            }
            return path;
        }
    }
}
