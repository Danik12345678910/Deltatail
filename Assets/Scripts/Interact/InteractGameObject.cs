using System;
using UnityEngine;
using Zenject;

abstract public class InteractGameObject : MonoBehaviour
{
    private bool _isInteracting;
    private int _currentInteractionIndex;

    [SerializeReference, SubclassSelector] private InteractionActionEndingHandler[] _actions;

    private EventBus _eventBus;
    private PlayerDataService _playerDataService;

    protected PlayerTouchCurrentGameObjectDetect _touchDetect;

    [Inject]
    private void Initialize(EventBus eventBus, PlayerDataService playerDataService)
    {

        _eventBus = eventBus;
        _playerDataService = playerDataService;
    }

    protected virtual void Awake()
    {
        _touchDetect = GetComponent<PlayerTouchCurrentGameObjectDetect>();
        if (_touchDetect == null)
            throw new NullReferenceException("Отсутствует детектор коллизии");
    }

    protected virtual void Start()
    {
        foreach (var action in _actions)
            action.Start();

        foreach (var action in _actions)
            action.OnEndingAction += DisableAction;

        _touchDetect.Initialize(_playerDataService.GameObject);
    }

    protected void Interact()
    {
        if (!_isInteracting)
        {
            EnableAction();

            _actions[_currentInteractionIndex].Action();
            _eventBus.Invoke(new InteractSignal());

            if (_currentInteractionIndex < _actions.Length - 1)
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
