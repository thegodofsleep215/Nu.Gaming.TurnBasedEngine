using System;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class ResetDeck : GameMessage
    {
        public PlayingCard[] PlayingCards { get; private set; } 

        public ResetDeck(Guid originatingGameObjectGuid, PlayingCard[] playingCards) : base(originatingGameObjectGuid)
        {
            PlayingCards = playingCards;
        }
    }
}