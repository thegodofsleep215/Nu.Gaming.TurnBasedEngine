using System;

namespace Nu.Gaming.TurnBasedEngine
{
    public abstract class GameZone : IGameObject
    {
        protected GameZone(Board board)
        {
            Board = board;
        }

        public Board Board { get; private set; }
        public Guid ObjectGuid { get; set; }
    }
}