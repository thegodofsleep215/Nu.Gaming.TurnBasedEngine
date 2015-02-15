using Nu.Gaming.TurnedBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class PlayCards : GameEvent
    {
        public PlayCards(IGameObject originatingGameObject, PlayingCard card, int finishZone) : base(originatingGameObject)
        {
            Cards = new[]{card};
        }
        public PlayCards(IGameObject originatingGameObject, PlayingCard[] cardses, int finishZone)
            : base(originatingGameObject)
        {
            Cards = cardses;
        }

        public PlayingCard[] Cards { get; private set; }
    }
}