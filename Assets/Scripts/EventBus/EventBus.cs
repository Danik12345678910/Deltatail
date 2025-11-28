using System;
using System.Collections.Generic;
using UnityEngine;

sealed public class EventBus 
{
    private Dictionary<string, List<Delegate>> _signalCallbacksMap = new Dictionary<string, List<Delegate>>();

    public void Subscribe<T>(in Action<T> callback) where T : ISignal
    {
        var key = typeof(T).Name;

        if (_signalCallbacksMap.ContainsKey(key))
            _signalCallbacksMap[key].Add(callback);
        else
            _signalCallbacksMap.Add(key, new List<Delegate>() { callback });
    }

    public void Unsubscribe<T>(in Action<T> callback) where T : ISignal
    {
        var key = typeof(T).Name;

        if (_signalCallbacksMap.ContainsKey(key))
            _signalCallbacksMap[key].Remove(callback);
        else
            Debug.LogError("Попытка отписаться не сработала.");
    }

    public void Invoke<T>(in T signal) where T : ISignal
    {
        var key = typeof(T).Name;

        if (_signalCallbacksMap.ContainsKey(key))
        {
            var copyArray = _signalCallbacksMap[key].ToArray();
            foreach (var obj in copyArray)
            {
                var callback = obj as Action<T>;
                callback?.Invoke(signal);
            }
        }
    }
}
