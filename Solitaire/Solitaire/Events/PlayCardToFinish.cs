using Nu.Gaming.TurnedBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class PlayCardToFinish : GameEvent
    {
        public int Position { get; private set; }

        public PlayingCard Card { get; private set; }
        public PlayCardToFinish(IGameObject originatingGameObject, int position, PlayingCard card) : base(originatingGameObject)
        {
            Card = card;
            Position = position;
        }
    }
}