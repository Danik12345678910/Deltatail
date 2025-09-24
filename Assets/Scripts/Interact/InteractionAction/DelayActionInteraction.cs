using System;
using UnityEngine;
using System.Collections;
[Serializable]

public class DelayActionInteraction : InteractionActionEndingHandler
{
    public override event System.Action OnEndingAction;
    private StarterCoroutine _starterCoroutine;
    [SerializeField, Min(0)] float _delayTimeInSeconds;

    public override void Initialize()
    {
        _starterCoroutine = ServiceLocator.Current.GetService<StarterCoroutine>();
    }

    public override void Action()
    {
        _starterCoroutine.StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(_delayTimeInSeconds);
        OnEndingAction?.Invoke();
    }
}