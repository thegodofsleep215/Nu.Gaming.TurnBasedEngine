using System;
using System.Collections.Generic;
using System.Linq;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;
using Solitaire.ViewModel;

namespace Solitaire
{
    public class SolitaireBoard : Board
    {
        private readonly Guid player;

        public SolitaireBoard(Guid player)
        {
            this.player = player;
            Subscribe<StartGame>(HandleStartGame);
            Subscribe<StepDeck>(HandleStepDeck);
        }


        private Deck deck;

        private Pile pile;

        // TODO: Maybe I should just make these arrays.
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
            var pz1 = Enumerable.Repeat((PlayingCard)null, pzOne.FaceDownCards.Count).ToList();
            pz1.AddRange(pzOne.FaceUpCards);
            var pz2 = Enumerable.Repeat((PlayingCard)null, pzTwo.FaceDownCards.Count).ToList();
            pz2.AddRange(pzTwo.FaceUpCards);
            var pz3 = Enumerable.Repeat((PlayingCard)null, pzThree.FaceDownCards.Count).ToList();
            pz3.AddRange(pzThree.FaceUpCards);
            var pz4 = Enumerable.Repeat((PlayingCard)null, pzFour.FaceDownCards.Count).ToList();
            pz4.AddRange(pzFour.FaceUpCards);
            var pz5 = Enumerable.Repeat((PlayingCard)null, pzFive.FaceDownCards.Count).ToList();
            pz5.AddRange(pzFive.FaceUpCards);
            var pz6 = Enumerable.Repeat((PlayingCard)null, pzSix.FaceDownCards.Count).ToList();
            pz6.AddRange(pzSix.FaceUpCards);
            var pz7 = Enumerable.Repeat((PlayingCard)null, pzSeven.FaceDownCards.Count).ToList();
            pz7.AddRange(pzSeven.FaceUpCards);
            return new VisibleGameState
            {
                CardsInDeck = deck.PlayingCards.Count,
                CardsInPile = pile.Cards.Count,
                FaceUpFinishCards = new[] {
                    fzOne.Cards.Count == 0 ? null : fzOne.Cards.Peek(),
                    fzTwo.Cards.Count == 0 ? null : fzTwo.Cards.Peek(),
                    fzThree.Cards.Count == 0 ? null : fzThree.Cards.Peek(),
                    fzFour.Cards.Count == 0 ? null : fzFour.Cards.Peek()},
                PlayZoneCards = new List<PlayingCard[]>
                {
                    pz1.ToArray(),
                    pz2.ToArray(),
                    pz3.ToArray(),
                    pz4.ToArray(),
                    pz5.ToArray(),
                    pz6.ToArray(),
                    pz7.ToArray(),
                },
                TopCardOfPile = pile.Cards.Any() ? pile.Cards.Peek() : null
            };
        }

        #region Events
        public event Action<VisibleGameState> GameStateUpdated;
        protected virtual void OnGameStateUpdated()
        {
            GameStateUpdated?.Invoke(GetGameState());
        }

   
        
        #endregion   


        #region Commands

        private void HandleStartGame(StartGame startGame)
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
            OnGameStateUpdated();
        }

        private void HandleStepDeck(StepDeck stepDeck)
        {
            if (deck.PlayingCards.Any())
            {
                deck.FlipCards();
            }
            else
            {
                pile.SendCardsToDeck();
            }
            OnGameStateUpdated();
        }
        

        #endregion


        public void StartGame()
        {
 
        }

    }

    public class StartGame : GameMessage{
        public StartGame(Guid originatingGameObjectGuid) : base(originatingGameObjectGuid)
        {
        }
    }

    public class StepDeck : GameMessage {
        public StepDeck(Guid originatingGameObjectGuid) : base(originatingGameObjectGuid)
        {
        }
    }

}