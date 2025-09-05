public class GameContextData<T>: IGameContextData
{
    public T ContextValue { get; private set; }

    public GameContextData(T contextValue)
    { this.ContextValue = contextValue; }
}