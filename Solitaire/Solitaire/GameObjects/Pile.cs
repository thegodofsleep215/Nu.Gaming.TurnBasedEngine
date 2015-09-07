using System;
using System.Collections.Generic;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.Events;

namespace Solitaire.GameObjects
{
    public class Pile : GameZone
    {
        public Stack<PlayingCard> Cards { get; set; }
        public Pile(Board board) : base(board)
        {
            ObjectGuid = Guid.NewGuid();
            Cards = new Stack<PlayingCard>();
            board.Subscribe<FlipCards>(ReceiveFlippedCards);
        }

        public void PlayCard(int finishZone)
        {
            Board.Publish(new PlayCards(ObjectGuid, Cards.Pop(), finishZone));
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
            Board.Publish(new ResetDeck(ObjectGuid, Cards.ToArray()));
        }
    }
}