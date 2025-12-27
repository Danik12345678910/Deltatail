using System;
using System.Collections.Generic;
using UnityEngine;

public struct InteractDependencyPack
{
    private Dictionary<Type, object> _map;
    
    public InteractDependencyPack(params object[] objects)
    {
        int count = objects.Length;
        Type[] types = new Type[count];

        for (int i = 0; i < count; i++)
            types[i] = objects[i].GetType();

        _map = new Dictionary<Type, object>();
        for (int i = 0; i < count; i++)
            _map.Add(types[i], objects[i]);
    }

    public T Get<T>()
    {
        var key = typeof(T);
        return (T)_map[key];
    }
}
