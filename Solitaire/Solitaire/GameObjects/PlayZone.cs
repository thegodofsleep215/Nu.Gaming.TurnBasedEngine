using System;
using System.Collections.Generic;
using System.Linq;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.Events;

namespace Solitaire.GameObjects
{
    public class PlayZone : GameZone
    {
        private readonly int playPosition;
        public Stack<PlayingCard> FaceDownCards { get; }

        public Stack<PlayingCard> FaceUpCards { get; } 

        public PlayZone(Board board, Stack<PlayingCard> faceDownCards, PlayingCard faceUpCard, int playPosition) : base(board)
        {
            ObjectGuid = Guid.NewGuid();
            FaceDownCards = faceDownCards;
            this.playPosition = playPosition;
            FaceUpCards = new Stack<PlayingCard>();
            FaceUpCards.Push(faceUpCard);
            board.Subscribe<PlayCards>(ReceivePlayedCards);
        }

        private void ReceivePlayedCards(PlayCards evt)
        {
            evt.Cards.ToList().ForEach(x => FaceUpCards.Push(x));
        }

        public void PlayCards(int topCount)
        {
            var cards = new PlayingCard[topCount];
            for (int i = 0; i < topCount; i++)
            {
                cards[0] = FaceUpCards.Pop();
            }
            TryTurnCardFaceUp();
        }

        public void PlayCardToFinsihZone(int position)
        {
            Board.Publish(new PlayCardToFinish(ObjectGuid, position, FaceUpCards.Pop()));
            TryTurnCardFaceUp();
        }

        private void TryTurnCardFaceUp()
        {
            if (FaceUpCards.Count == 0 && FaceDownCards.Count > 0)
            {
                Board.Publish(new PlayCards(ObjectGuid, FaceDownCards.Pop(), playPosition));
            }
        }
    }
}