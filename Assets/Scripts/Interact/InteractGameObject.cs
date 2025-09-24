using System;
using UnityEngine;

abstract public class InteractGameObject : MonoBehaviour
{
    private bool _isInteracting;
    private int _currentInteractionIndex;
    
    [SerializeReference, SubclassSelector] private InteractionActionEndingHandler[] _actions;

    private EventBus _eventBus;

    protected PlayerTouchCurrentGameObjectDetect _touchDetect;
     
    protected virtual void Awake()
    {
        _touchDetect = GetComponent<PlayerTouchCurrentGameObjectDetect>();
        if (_touchDetect == null)
            throw new NullReferenceException("Отсутствует детектор коллизии");
    }

    protected virtual void Start()
    {
        _eventBus = ServiceLocator.Current.GetService<EventBus>();

        foreach (var action in _actions)
            action.Initialize();

        foreach (var action in _actions)
            action.OnEndingAction += DisableAction;

        _touchDetect.Initialize(ServiceLocator.Current.GetService<PlayerDataService>().gameObject);
    }

    protected void Interact()
    {
        if(!_isInteracting)
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

    protected virtual void OnDestroy()
    {
        foreach (var action in _actions)
            action.OnEndingAction -= DisableAction;

        foreach (var action in _actions)
            action.Disable();
    }
}
