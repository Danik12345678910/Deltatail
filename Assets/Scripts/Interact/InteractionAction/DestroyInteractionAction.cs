using System;
using UnityEngine;
[Serializable]

public class DestroyInteractionAction : InteractionActionEndingHandler
{
    public override event System.Action OnEndingAction;
    [SerializeField] private GameObject _destroyGameObject;

    public override void Action()
    {
        GameObject.Destroy(_destroyGameObject);
        OnEndingAction?.Invoke();
    }
}