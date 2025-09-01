using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventBus : MonoBehaviourService
{
    private Dictionary<string, List<Delegate>> _signalCallbacksMap = new Dictionary<string, List<Delegate>>();

    public override Type ServiceType => GetType();

    public void Subscribe<T>(Action<T> callback) where T : ISignal
    {
        var key = typeof(T).Name;

        if (_signalCallbacksMap.ContainsKey(key))
            _signalCallbacksMap[key].Add(callback);
        else
            _signalCallbacksMap.Add(key, new List<Delegate>() { callback });
    }

    public void Unsubscribe<T>(Action<T> callback) where T : ISignal
    {
        var key = typeof(T).Name;

        if (_signalCallbacksMap.ContainsKey(key))
            _signalCallbacksMap[key].Remove(callback);
        else
            Debug.LogError("Попытка отписаться не сработала.");
    }

    public void Invoke<T>(T signal) where T : ISignal
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
