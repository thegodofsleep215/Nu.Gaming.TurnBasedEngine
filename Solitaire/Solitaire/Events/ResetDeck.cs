using Nu.Gaming.TurnedBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class ResetDeck : GameEvent
    {
        public PlayingCard[] PlayingCards { get; private set; } 

        public ResetDeck(IGameObject originatingGameObject, PlayingCard[] playingCards) : base(originatingGameObject)
        {
            PlayingCards = playingCards;
        }
    }
}