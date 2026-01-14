using System;
using System.Collections.Generic;

public readonly struct InteractDependencyPack
{
    private readonly Dictionary<Type, object> _map;

    public InteractDependencyPack(params (Type type, object value)[] entries)
    {
        _map = new Dictionary<Type, object>();

        foreach (var e in entries)
        {
            if (!_map.TryAdd(e.type, e.value))
                throw new Exception("Дубликат интерфейса: " + e.type);
        }
    }

    public T Get<T>()
    {
        if(_map.ContainsKey(typeof(T)))
            return (T)_map[typeof(T)];
        else throw new NullReferenceException("Данный тип отсутствует в пакете");
    }
}

public static class Bind
{
    public static (Type, object) As<T>(T obj) => (typeof(T), obj!);
}