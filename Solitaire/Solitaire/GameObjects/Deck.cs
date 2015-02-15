using System;
using System.Collections.Generic;
using System.Linq;
using Nu.Gaming.TurnedBasedEngine;
using Solitaire.Events;

namespace Solitaire.GameObjects
{
    public class Deck : GameZone
    {
        private readonly int cardsPerFlip;
        public Stack<PlayingCard> PlayingCards { get; private set; }

        public Deck(Board board, Stack<PlayingCard> shuffledDeck, int cardsPerFlip = 3) : base(board)
        {
            this.cardsPerFlip = cardsPerFlip;
            board.Subscribe<ResetDeck>(ResetDeckCallBack);
            PlayingCards = shuffledDeck;
        }

        public void FlipCards()
        {
            var numOfCards = Math.Min(cardsPerFlip, PlayingCards.Count);
            var cardsToSend = new PlayingCard[numOfCards];
            for (int i = 0; i < numOfCards; i++)
            {
                cardsToSend[i] = PlayingCards.Pop();
            }
            Board.Publish(new FlipCards(this, cardsToSend));
        }

        public void ResetDeckCallBack(ResetDeck evt)
        {
            evt.PlayingCards.ToList().ForEach(x => PlayingCards.Push(x));
        }

    }
}