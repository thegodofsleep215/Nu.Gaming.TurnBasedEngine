using System.Collections.Generic;
using Nu.Gaming.TurnedBasedEngine;
using Solitaire.Events;

namespace Solitaire.GameObjects
{
    public class Pile : GameZone
    {
        public Stack<PlayingCard> Cards { get; set; }
        public Pile(Board board) : base(board)
        {
            Cards = new Stack<PlayingCard>();
            board.Subscribe<FlipCards>(ReceiveFlippedCards);
        }

        public void PlayCard(int finishZone)
        {
            Board.Publish(new PlayCards(this, Cards.Pop(), finishZone));
        }

        private void ReceiveFlippedCards(FlipCards flippedCards)
        {
            foreach (var card in flippedCards.FlippedCards)
            {
                Cards.Push(card);
            }
        }

        public void SendCardsToDeck()
        {
            Cards.Clear();
            Board.Publish(new ResetDeck(this, Cards.ToArray()));
        }
    }
}