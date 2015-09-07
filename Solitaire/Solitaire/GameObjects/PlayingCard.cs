using System;
using System.Collections.Generic;
using System.Linq;
using Nu.Gaming.TurnBasedEngine;

namespace Solitaire.GameObjects
{
        public enum Suite
        {
            Clubs,
            Hearts,
            Spades,
            Diamonds
        }

        public enum CardValue
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen =12,
            King = 13,
            Ace = 14,
        }
    public class PlayingCard : IGameObject
    {
        public PlayingCard(Suite suite, CardValue cardValue)
        {
            ObjectGuid = Guid.NewGuid();
            CardSuite = suite;
            CardValue = cardValue;
        }

        public Suite CardSuite { get; set; }

        public CardValue CardValue { get; set; }
        public static Stack<PlayingCard> CreateShuffledDeck()
        {
            var cards = new List<PlayingCard>();
            for (int i = 0; i < 4; i++)
            {
                cards.AddRange(Enumerable.Range(1, 14) .ToList() .Select(x => new PlayingCard((Suite) i, (CardValue) x)));
            }

            var result = new Stack<PlayingCard>();
            var rand = new Random();
            while (cards.Count > 0)
            {
                var index = rand.Next(0, cards.Count);
                result.Push(cards[index]);
                cards.RemoveAt(index);
            }
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", CardValue, CardSuite);
        }

        public Guid ObjectGuid { get; set; }
    }
}