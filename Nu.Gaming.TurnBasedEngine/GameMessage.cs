using System;

namespace Nu.Gaming.TurnBasedEngine
{
    public class GameMessage
    {
        public GameMessage(Guid originatingGameObjectGuid)
        {
            OriginatingGameObjectGuid = originatingGameObjectGuid;
        }

        public Guid OriginatingGameObjectGuid { get; set; }
    }
}