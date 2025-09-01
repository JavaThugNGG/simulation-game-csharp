namespace Simulation
{
    internal abstract class Entity
    {
        internal Entity(Coordinates coordinates, string figure)
        {
            Coordinates = coordinates;
            Figure = figure;
        }

        public Coordinates Coordinates { get; set; }

        public string Figure { get; init; }

        public override string ToString() => Figure;
    }
}
