using System;
using UnityEngine;

[Serializable]
public class MultiInteractionAction : InteractionActionEndingHandler
{
    [SerializeReference, SubclassSelector] private InteractionAction[] _listInteractionsActions;

    public override event Action OnEndingAction;

    public override void Initialize()
    {
        foreach (InteractionAction action in _listInteractionsActions)
            action.Initialize();
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