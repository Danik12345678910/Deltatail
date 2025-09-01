using System;
using UnityEngine;
using MackySoft.SerializeReferenceExtensions;

public class InteractGameObject : MonoBehaviour
{
    private bool _isPlayerCollision;
    private bool _isInteracting;
    private int _currentInteractionIndex;
    private IInteractInput _interactInput;
    [SerializeReference, SubclassSelector] private InteractionActionEndingHandler[] _actions;

    private EventBus _eventBus;

    public void Initialize(IInteractInput interactInput)
    {
        _eventBus = ServiceLocator.Current.GetService<EventBus>();
        _interactInput = interactInput;
        _interactInput.OnInput += Interact;

        foreach (var action in _actions)
            action.Initialize();

        foreach (var action in _actions)
            action.OnEndingAction += DisableAction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerDataService playerData))
            SetPlayerCollision();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerDataService playerData))
            UnsetPlayerCollision();
    }

    private void SetPlayerCollision() => _isPlayerCollision = true;
    private void UnsetPlayerCollision() => _isPlayerCollision = false;

    private void Interact()
    {
        if(_isPlayerCollision && !_isInteracting)
        {
            EnableAction();

            _actions[_currentInteractionIndex].Action();
            _eventBus.Invoke(new InteractSignal());

            if(_currentInteractionIndex < _actions.Length - 1)
                _currentInteractionIndex++;
        }
    }

    private void EnableAction()
    {
        _isInteracting = true;
    }

    private void DisableAction()
    {
        _isInteracting = false;   
    }

    private void OnDestroy()
    {
        _interactInput.OnInput -= Interact;

        foreach (var action in _actions)
            action.OnEndingAction -= DisableAction;

        foreach (var action in _actions)
            action.Disable();
    }
}
