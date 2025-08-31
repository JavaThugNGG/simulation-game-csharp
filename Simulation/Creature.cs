namespace Simulation
{
    internal abstract class Creature : Entity
    {
        internal delegate void MoveHandler(object sender, Coordinates oldCoordinates, Coordinates newCoordinates);
        internal event MoveHandler Moved;

        internal Creature(Coordinates coordinates, string figure) : base(coordinates, figure) { }//предупреждение уйдет когда на событие подпишутся

        internal void MakeMove(Coordinates newCoordinates)
        {
            Coordinates oldCoordinates = Coordinates;
            Coordinates = newCoordinates;
            OnMove(oldCoordinates, newCoordinates);
        }

        private void OnMove(Coordinates oldCoordinates, Coordinates newCoordinates)
        {
            Moved?.Invoke(this, oldCoordinates, newCoordinates);
        }
    }
}
