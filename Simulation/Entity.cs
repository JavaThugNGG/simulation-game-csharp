namespace Simulation
{
    internal abstract class Entity
    {
        internal Entity(Coordinates coordinates, string figure)
        {
            Coordinates = coordinates;
            Figure = figure;
        }

        protected Coordinates Coordinates { get; set; }

        protected string Figure { get; init; }

        public override string ToString() => Figure;
    }
}
