namespace Simulation
{
    internal abstract class Entity
    {
        internal Entity(Coordinates coordinates, string figure)
        {
            Coordinates = coordinates;
            Figure = figure;
        }

        internal Coordinates Coordinates { get; set; }

        internal string Figure { get; init; }

        public override string ToString() => Figure;
    }
}
