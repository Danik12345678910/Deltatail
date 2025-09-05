using System;
using System.Collections.Generic;

public class FSM<T> where T : State
{
    public T CurrentState { get; private set; }
    private Dictionary<Type, T> _stateMap;

    public void SetCurrentState<T2>() where T2 : T
    {
        if(CurrentState != null)
            CurrentState.Exit();

        CurrentState = GetState<T2>();

        CurrentState.Enter();
    }

    public void Initialize(params T[] values) 
    {
        _stateMap = new Dictionary<Type, T>();

        foreach (var value in values)
            AddState(value);
    }

    private void AddState<T2>(T2 newState) where T2 : T
    {
        var key = typeof(T2);

        if (_stateMap.ContainsKey(key))
            throw new InvalidOperationException($"Состояние, хранящееся под ключом {key} уже существует.");

        _stateMap.Add(key, newState);
    }

    private T GetState<T2>() where T2 : T
    {
        var key = typeof(T2);

        if (!_stateMap.ContainsKey(key))
            throw new InvalidOperationException($"Состояние не хранится под ключом {key}.");


        return _stateMap[key];
    }
    public void Update() => CurrentState.Update();
}
