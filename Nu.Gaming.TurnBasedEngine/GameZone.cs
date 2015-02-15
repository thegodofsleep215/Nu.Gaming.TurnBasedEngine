namespace Nu.Gaming.TurnedBasedEngine
{
    public abstract class GameZone : IGameObject
    {
        protected GameZone(Board board)
        {
            Board = board;
        }

        public Board Board { get; private set; }
    }
}