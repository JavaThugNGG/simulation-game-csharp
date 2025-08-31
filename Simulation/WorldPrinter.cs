namespace Simulation
{
    internal class WorldPrinter
    {
        internal void Print(IDictionary<Coordinates, Entity> inputDictionary)
        {
            Console.WriteLine();
            for (int i = 0; i < SimulationManager.WorldRows; i++)
            {
                for (int j = 0; j < SimulationManager.WorldColumns; j++)
                {
                    Coordinates coordinate = new Coordinates(i, j);

                    if (inputDictionary.TryGetValue(coordinate, out Entity? entity))
                    {
                        Console.Write(entity);
                    }
                    else
                    {
                        Console.Write("⬛");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
