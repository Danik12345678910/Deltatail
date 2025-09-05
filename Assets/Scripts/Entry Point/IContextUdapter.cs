public interface IContextUpdater
{
    public void Initialize();
    public void SubscribeToWriteContext();
    public void UnsubscribeToWriteContext();
}