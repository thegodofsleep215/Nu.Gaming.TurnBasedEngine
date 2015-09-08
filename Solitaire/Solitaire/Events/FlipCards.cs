using System;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class FlipCards : GameMessage
    {
        public FlipCards(Guid originatingGameObjectGuid, PlayingCard[] flippedCards) : base(originatingGameObjectGuid)
        {
            FlippedCards = flippedCards;
        }

        public PlayingCard[] FlippedCards { get; private set; } 

    }
}