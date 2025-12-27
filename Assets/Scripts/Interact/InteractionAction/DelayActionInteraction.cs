using System;
using UnityEngine;
using System.Collections;
using Zenject;
[Serializable]

public class DelayActionInteraction : InteractionActionEndingHandler
{
    public override event System.Action OnEndingAction;
    private ControllerCoroutine _starterCoroutine;
    [SerializeField, Min(0)] float _delayTimeInSeconds;

    public override void Initialize(InteractDependencyPack pack)
    {
        _starterCoroutine = pack.Get<ControllerCoroutine>();
    }
    public override void Action() => _starterCoroutine.StartCoroutine(DelayCoroutine());

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(_delayTimeInSeconds);
        OnEndingAction?.Invoke();
    }
}