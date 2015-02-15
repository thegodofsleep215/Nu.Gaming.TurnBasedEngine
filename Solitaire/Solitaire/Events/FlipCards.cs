using Nu.Gaming.TurnedBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class FlipCards : GameEvent
    {
        public FlipCards(IGameObject originatingGameObject, PlayingCard[] flippedCards) : base(originatingGameObject)
        {
            FlippedCards = flippedCards;
        }

        public PlayingCard[] FlippedCards { get; private set; } 

    }
}