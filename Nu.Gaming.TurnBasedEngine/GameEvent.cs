using System;

namespace Nu.Gaming.TurnBasedEngine
{
    public class GameEvent
    {
        public GameEvent(Guid originatingGameObjectGuid)
        {
            OriginatingGameObjectGuid = originatingGameObjectGuid;
        }

        public Guid OriginatingGameObjectGuid { get; set; }
    }
}