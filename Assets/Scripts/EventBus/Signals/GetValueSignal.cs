abstract public class GetValueSignal<T> : ISignal
{
    public T Value { get; private set; }

    public GetValueSignal(T value)
    {
        Value = value;
    }
}