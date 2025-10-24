public class EventContextUpdater<TValue> where TValue : IValueEventContext
{
    private EventBus _eventBus;
    private GameContext _gameContext;

    public void Initialize(EventBus eventBus, GameContext gameContext)
    {
        _eventBus = eventBus;
        _gameContext = gameContext;
    }

    public void SubscribeToWriteContext()
    {
        _eventBus.Subscribe<GetValueSignal<TValue>>(WriteContextByValue);
    }
    public void UnsubscribeToWriteContext()
    {
        _eventBus.Unsubscribe<GetValueSignal<TValue>>(WriteContextByValue);
    }

    private void WriteContextByValue(GetValueSignal<TValue> signal)
    {
        var valueContext = signal.Value;
        GameContextData<TValue> context = new GameContextData<TValue>(valueContext);//ПРОБЛЕМНАЯ ТОЧКА, ИЗ-ЗА КОТОРОЙ Я ВПАЛ ВРАЗДУМИЯ!!!!! ВЕДЬ ПО ТАКОМУ ЖЕ ПРИНЦИПУ МОЖНО СДЕЛАТЬ И СИГНАЛ. УБРАВ НАСЛЕДНИКИ(ИНАЧЕ ВСЕ ПОЛЕТИТ)
        _gameContext.WriteContext(context);
    }
}

public interface IValueEventContext { }