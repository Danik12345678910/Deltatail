using System;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    public const string tagGameContext = "GameContext";

    private Dictionary<Type, IGameContext> _contextsMap = new Dictionary<Type, IGameContext>();
    private EventBus _eventBus;

    private void Awake()
    {
        if (tag != tagGameContext)
            throw new InvalidOperationException("Игровой тег не равен тегу объекта");

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _eventBus = ServiceLocator.Current.GetService<EventBus>();
    }

    public void WriteContext<T>(T context) where T : IGameContext
    {
        var key = typeof(T);

        if(_contextsMap.ContainsKey(key))
            _contextsMap[key] = context;
        else
            _contextsMap.Add(key, context);
    }

    public T ReadContext<T>() where T : IGameContext
    {
        var key = typeof(T);

        if (!_contextsMap.ContainsKey(key))
            throw new NullReferenceException("Отсутствие контекста по такому ключу");

        return (T) _contextsMap[key];
    }
}
