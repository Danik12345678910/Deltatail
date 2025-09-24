using System;
using System.Collections.Generic;

public class GameContext : MonoBehaviourService
{
    private Dictionary<Type, IGameContextData> _contextsMap = new Dictionary<Type, IGameContextData>();

    public override Type ServiceType => GetType();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void WriteContext<T>(T context) where T : IGameContextData
    {
        var key = typeof(T);

        if(_contextsMap.ContainsKey(key))
            _contextsMap[key] = context;
        else
            _contextsMap.Add(key, context);
    }

    public T ReadContext<T>() where T : IGameContextData
    {
        var key = typeof(T);

        if (!_contextsMap.ContainsKey(key))
            throw new NullReferenceException("Отсутствие контекста по такому ключу");

        return (T) _contextsMap[key];
    }
}
