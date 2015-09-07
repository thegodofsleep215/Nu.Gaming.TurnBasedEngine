using System;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class PlayCardToFinish : GameEvent
    {
        public int Position { get; private set; }

        public PlayingCard Card { get; private set; }
        public PlayCardToFinish(Guid originatingGameObjectGuid, int position, PlayingCard card) : base(originatingGameObjectGuid)
        {
            Card = card;
            Position = position;
        }
    }
}