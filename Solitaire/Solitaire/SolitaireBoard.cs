using System;
using System.Collections.Generic;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;
using Solitaire.ViewModel;

namespace Solitaire
{
    public class SolitaireBoard : Board
    {
        private Deck deck;

        private Pile pile;

        private FinishZone fzOne;
        private FinishZone fzTwo;
        private FinishZone fzThree;
        private FinishZone fzFour;

        private PlayZone pzOne;
        private PlayZone pzTwo;
        private PlayZone pzThree;
        private PlayZone pzFour;
        private PlayZone pzFive;
        private PlayZone pzSix;
        private PlayZone pzSeven;

        private VisibleGameState GetGameState()
        {
            return new VisibleGameState
            {
                CardsInDeck = deck.PlayingCards.Count,
                CardsInPile = pile.Cards.Count,
            };
        }

        public event Action<VisibleGameState> GameStateUpdated;



        public SolitaireBoard()
        {
            pile = new Pile(this);
            fzOne = new FinishZone(this);
            fzTwo = new FinishZone(this);
            fzThree = new FinishZone(this);
            fzFour = new FinishZone(this);

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

        protected virtual void OnGameStateUpdated()
        {
            GameStateUpdated?.Invoke(GetGameState());
        }
    }
}