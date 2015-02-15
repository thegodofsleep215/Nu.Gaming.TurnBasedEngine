using System.Collections.Generic;
using Nu.Gaming.TurnedBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire
{
    public class SolitaireBoard : Board
    {
        private Deck deck;

        private Pile pile;

        private FinsihZone fzOne;
        private FinsihZone fzTwo;
        private FinsihZone fzThree;
        private FinsihZone fzFour;

        private PlayZone pzOne;
        private PlayZone pzTwo;
        private PlayZone pzThree;
        private PlayZone pzFour;
        private PlayZone pzFive;
        private PlayZone pzSix;
        private PlayZone pzSeven;

        public SolitaireBoard()
        {
            pile = new Pile(this);
            fzOne = new FinsihZone(this);
            fzTwo = new FinsihZone(this);
            fzThree = new FinsihZone(this);
            fzFour = new FinsihZone(this);

            var cards = PlayingCard.CreateShuffledDeck();

            pzOne = new PlayZone(this, new Stack<PlayingCard>(),cards.Pop(), 1);

            var stack = new Stack<PlayingCard>(new [] {cards.Pop()});
            pzTwo = new PlayZone(this, stack, cards.Pop(), 2);

            stack = new Stack<PlayingCard>(new[] { cards.Pop(), cards.Pop()});
            pzThree = new PlayZone(this, stack, cards.Pop(), 3);

            stack = new Stack<PlayingCard>(new [] {cards.Pop(), cards.Pop(), cards.Pop()});
            pzFour = new PlayZone(this, stack, cards.Pop(), 4);

            stack = new Stack<PlayingCard>(new [] {cards.Pop(), cards.Pop(),cards.Pop(), cards.Pop()});
            pzFive = new PlayZone(this, stack, cards.Pop(), 5);

            stack = new Stack<PlayingCard>(new [] {cards.Pop(), cards.Pop(), cards.Pop(), cards.Pop(), cards.Pop()});
            pzSix = new PlayZone(this, stack, cards.Pop(), 6);

            stack = new Stack<PlayingCard>(new [] {cards.Pop(), cards.Pop(), cards.Pop(), cards.Pop(), cards.Pop(), cards.Pop()});
            pzSeven = new PlayZone(this, stack, cards.Pop(), 7);

            deck = new Deck(this, cards);
        }

    }
}