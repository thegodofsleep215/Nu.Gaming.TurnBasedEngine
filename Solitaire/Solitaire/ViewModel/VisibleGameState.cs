using Solitaire.GameObjects;

namespace Solitaire.ViewModel
{
    public class VisibleGameState
    {
        public int CardsInDeck { get; set; }

        public int CardsInPile { get; set; }

        public int CardsInPlayZoneOne { get; set; }

        public int CardsInPlayZoneTwo { get; set; }

        public int CardsInPlayZoneThree { get; set; }

        public int CardsInPlayZoneFour{ get; set; }

        public int CardsInPlayZoneFive { get; set; }

        public int CardsInPlayZoneSix { get; set; }

        public int CardsInPlayZoneSeven { get; set; }

        public PlayingCard FaceUpPileOne { get; set; }
        
        public PlayingCard FaceUpPileTwo { get; set; }
        
        public PlayingCard FaceUpPileThree { get; set; }
        
        public PlayingCard FaceUpPileFour { get; set; }
        
        public PlayingCard FaceUpPileFive { get; set; }
        
        public PlayingCard FaceUpPileSix { get; set; }

        public PlayingCard FaceUpPileSeven { get; set; }

        public PlayingCard FaceUpFinishOne { get; set; }
        
        public PlayingCard FaceUpFinishTwo { get; set; }
        
        public PlayingCard FaceUpFinishThree { get; set; }

        public PlayingCard FaceUpFinishFour { get; set; }

    }
}