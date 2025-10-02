abstract public class EventContextUpdater<TSignal, TValue> : IContextUpdater where TSignal : GetValueSignal<TValue> //ЕГО Я ДУМАЮ ПООМ ОСТАВЛЮ GENERIC БЕЗ ABSTRACT
{
    //protected abstract TSignal Signal { get; }
    private EventBus _eventBus;
    private GameContext _gameContext;

    public void Initialize(EventBus eventBus, GameContext gameContext)
    {
        _eventBus = eventBus;
        _gameContext = gameContext;
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
        GameContextData<TValue> context = new GameContextData<TValue>(valueContext);//ПРОБЛЕМНАЯ ТОЧКА, ИЗ-ЗА КОТОРОЙ Я ВПАЛ ВРАЗДУМИЯ!!!!! ВЕДЬ ПО ТАКОМУ ЖЕ ПРИНЦИПУ МОЖНО СДЕЛАТЬ И СИГНАЛ. УБРАВ НАСЛЕДНИКИ(ИНАЧЕ ВСЕ ПОЛЕТИТ)
        _gameContext.WriteContext(context);
    }
}