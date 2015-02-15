using Nu.Gaming.TurnedBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class SuiteFinished : GameEvent
    {
        public Suite CardSuite { get; private set; }

        public SuiteFinished(IGameObject originatingGameObject, Suite cardSuite) : base(originatingGameObject)
        {
            CardSuite = cardSuite;
        }
    }
}