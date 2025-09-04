namespace Simulation
{
    internal record Coordinates(int Row, int Column) : IComparable<Coordinates>
    {
        public override string ToString() => $"{Row} {Column}";

        public int CompareTo(Coordinates? other) => (Row, Column).CompareTo((other!.Row, other.Column));
    }
}