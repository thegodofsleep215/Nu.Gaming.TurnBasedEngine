using System.Collections.Generic;
using Nu.Gaming.TurnedBasedEngine;
using Solitaire.Events;

namespace Solitaire.GameObjects
{
    public class FinishZone : GameZone
    {
        public Stack<PlayingCard> Cards { get; private set; }

        public FinishZone(Board board) : base(board)
        {
            Cards = new Stack<PlayingCard>();
        }

        public void ReceiveCard(PlayCardToFinish evt)
        {
            Cards.Push(evt.Card);
            if (Cards.Count == 13)
            {
                Board.Publish(new SuiteFinished(this, evt.Card.CardSuite));
            }
        }
    }
}