using System;
using UnityEngine;

[Serializable]
public class SequenceInteractionAction : InteractionActionEndingHandler
{
    [SerializeReference, SubclassSelector] private InteractionActionEndingHandler[] _listInteractionsActions;

    public override event System.Action OnEndingAction;
    private bool _isSubscribed;

    public override void Initialize()
    {
        _isSubscribed = false;
        foreach (var action in _listInteractionsActions)
            action.Initialize();
    }

    public override void Action()
    {
        if (!_isSubscribed)
        {
            var actionOld = _listInteractionsActions[0];
            for (int i = 1; i < _listInteractionsActions.Length; i++)
            {
                actionOld.OnEndingAction += _listInteractionsActions[i].Action;
                actionOld = _listInteractionsActions[i];
            }

            _listInteractionsActions[_listInteractionsActions.Length - 1].OnEndingAction += OnEndingAction;
        }
        _listInteractionsActions[0].Action();
    }

    public override void Disable()
    {
        var actionOld = _listInteractionsActions[0];
        for (int i = 1; i < _listInteractionsActions.Length; i++)
        {
            actionOld.OnEndingAction -= _listInteractionsActions[i].Action;
            actionOld = _listInteractionsActions[i];
        }

        foreach (var action in _listInteractionsActions)
            action.Disable();

        _listInteractionsActions[_listInteractionsActions.Length - 1].OnEndingAction -= OnEndingAction;
    }
}