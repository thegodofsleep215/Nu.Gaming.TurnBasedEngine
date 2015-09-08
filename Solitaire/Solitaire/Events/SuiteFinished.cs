using System;
using Nu.Gaming.TurnBasedEngine;
using Solitaire.GameObjects;

namespace Solitaire.Events
{
    public class SuiteFinished : GameMessage
    {
        public Suite CardSuite { get; private set; }

        public SuiteFinished(Guid originatingGameObjectGuid, Suite cardSuite) : base(originatingGameObjectGuid)
        {
            CardSuite = cardSuite;
        }
    }
}