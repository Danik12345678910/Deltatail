abstract public class EventContextUpdater<TSignal, TValue> : IContextUpdater where TSignal : GetValueSignal<TValue>
{
    protected abstract TSignal Signal { get; }
    private EventBus _eventBus;
    private GameContext _gameContext;

    public void Initialize()
    {
        _eventBus = ServiceLocator.Current.GetService<EventBus>();
        _gameContext = ServiceLocator.Current.GetService<GameContext>();
    }

    public void SubscribeToWriteContext()
    {
        _eventBus.Subscribe<TSignal>(WriteContextByValue);
    }
    public void UnsubscribeToWriteContext()
    {
        _eventBus.Unsubscribe<TSignal>(WriteContextByValue);
    }

    private void WriteContextByValue(TSignal signal)
    {
        var valueContext = signal.Value;
        GameContextData<TValue> context = new GameContextData<TValue>(valueContext);
        _gameContext.WriteContext(context);
    }
}