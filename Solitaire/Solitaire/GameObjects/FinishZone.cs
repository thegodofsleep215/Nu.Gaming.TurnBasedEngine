using System;
using System.Collections.Generic;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.Events;

namespace Solitaire.GameObjects
{
    public class FinishZone : GameZone
    {
        public Stack<PlayingCard> Cards { get; }

        public FinishZone(Board board) : base(board)
        {
            ObjectGuid = Guid.NewGuid();
            Cards = new Stack<PlayingCard>();
        }

        public void ReceiveCard(PlayCardToFinish evt)
        {
            Cards.Push(evt.Card);
            if (Cards.Count == 13)
            {
                Board.Publish(new SuiteFinished(ObjectGuid, evt.Card.CardSuite));
            }
        }
    }
}