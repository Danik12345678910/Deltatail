using System;
using UnityEngine;
using Zenject;

abstract public class InteractGameObject : MonoBehaviour
{
    private bool _isInteracting;
    private int _currentInteractionIndex;

    [SerializeReference, SubclassSelector] private InteractionActionEndingHandler[] _actions;

    private EventBus _eventBus;
    private PlayerData _playerDataService;
    private InteractDependencyPack _pack;

    protected PlayerTouchCurrentGameObjectDetect _touchDetect;

    [Inject]
    private void Initialize(EventBus eventBus, PlayerData playerDataService, ControllerCoroutine controllerCoroutine, AudioController audioController, IDialogStartable<DialogData> dialogStartable, IDialogStartable<MainPersonDialogData> mainPersonDialogStartable)
    {
        _eventBus = eventBus;
        _playerDataService = playerDataService;
        Debug.Log(((IDialogStartable<MainPersonDialogData>)mainPersonDialogStartable).GetType().Name + " " + dialogStartable.GetType().Name);
        _pack = new InteractDependencyPack(Bind.As(_eventBus), Bind.As(controllerCoroutine), Bind.As(audioController), Bind.As(dialogStartable), Bind.As(mainPersonDialogStartable));
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
            action.Initialize(_pack);

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