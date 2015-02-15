namespace Nu.Gaming.TurnedBasedEngine
{
    public class GameEvent
    {
        public GameEvent(IGameObject originatingGameObject)
        {
            OriginatingGameObject = originatingGameObject;
        }

        public IGameObject OriginatingGameObject { get; set; }
    }
}