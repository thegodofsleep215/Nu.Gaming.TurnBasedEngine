using System;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class PlayCards : GameMessage
    {
        public PlayCards(Guid originatingGameObjectGuid, PlayingCard card, int finishZone) : base(originatingGameObjectGuid)
        {
            Cards = new[]{card};
        }
        public PlayCards(Guid originatingGameObjectGuid, PlayingCard[] cardses, int finishZone)
            : base(originatingGameObjectGuid)
        {
            Cards = cardses;
        }

        public PlayingCard[] Cards { get; private set; }
    }
}