using System;
using UnityEngine;

[Serializable]
public class MultiInteractionAction : InteractionActionEndingHandler
{
    [SerializeReference, SubclassSelector] private InteractionAction[] _listInteractionsActions;

    public override event System.Action OnEndingAction;

    public override void Start()
    {
        foreach (InteractionAction action in _listInteractionsActions)
            action.Start();
    }

    public override void Action()
    {
        foreach (InteractionAction action in _listInteractionsActions)
            action.Action();
        OnEndingAction?.Invoke();
    }

    public override void Disable()
    {
        foreach (InteractionAction action in _listInteractionsActions)
            action.Disable();
    }
}