using System;
using System.Collections.Generic;

sealed public class GameContext
{
    private Dictionary<Type, IGameContextData> _contextsMap = new Dictionary<Type, IGameContextData>();

    public void WriteContext<T>(in T context) where T : IGameContextData
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
