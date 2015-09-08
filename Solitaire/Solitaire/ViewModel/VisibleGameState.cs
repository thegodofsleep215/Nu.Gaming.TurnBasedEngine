using System.Collections.Generic;
using System.Linq;
using Solitaire.GameObjects;

namespace Solitaire.ViewModel
{
    public class VisibleGameState
    {
        public VisibleGameState()
        {
            FaceUpFinishCards = new PlayingCard[4];
            PlayZoneCards = Enumerable.Repeat(new PlayingCard[0], 7).ToList(); 
        }
        public int CardsInDeck { get; set; }

        public int CardsInPile { get; set; }

        public PlayingCard TopCardOfPile { get; set; }

        public List<PlayingCard[]> PlayZoneCards { get; set; }
        
        public PlayingCard[] FaceUpFinishCards { get; set; }
    }
}