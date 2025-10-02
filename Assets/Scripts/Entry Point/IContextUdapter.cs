public interface IContextUpdater
{
    public void Initialize(EventBus eventBus, GameContext context);
    public void SubscribeToWriteContext();
    public void UnsubscribeToWriteContext();
}