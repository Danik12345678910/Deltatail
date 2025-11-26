using System;
using UnityEngine;
using Zenject;

[Serializable]
sealed public class DialogFullInteractionAction : InteractionActionEndingHandler
{
    [SerializeField] private MainPersonDialogData _dialog;

    private event Action OnSubscribeHandler;
    private bool _isSubscribed;
    private EventBus _eventBus;
    private IDialogStartable<MainPersonDialogData> _mainPersonDialogStartable;

    public override event Action OnEndingAction;

    [Inject]
    private void Initialize(IDialogStartable<MainPersonDialogData> mainPersonDialogStartable) => _mainPersonDialogStartable = mainPersonDialogStartable;

    public override void Start()
    {
        OnSubscribeHandler += Unsubscribe;

        _eventBus = ServiceLocator.Current.GetService<EventBus>();
    }

    private void Subscribe()
    {
        if (_isSubscribed)
            return;

        _isSubscribed = true;

        _eventBus.Subscribe<DialogEndedSignal>(EndAction);
        _eventBus.Subscribe<DialogEndedSignal>(SubscribeHandler);
    }

    private void EndAction(DialogEndedSignal signal)
    {
        OnEndingAction?.Invoke();
    }

    private void SubscribeHandler(DialogEndedSignal signal)
    {
        OnSubscribeHandler?.Invoke();
    }

    private void Unsubscribe()
    {
        _isSubscribed = false;

        _eventBus.Unsubscribe<DialogEndedSignal>(EndAction);
        _eventBus.Unsubscribe<DialogEndedSignal>(SubscribeHandler);
    }

    public override void Disable()
    {
        Unsubscribe();
        OnSubscribeHandler -= Unsubscribe;
    }

    public override void Action()
    {
        Subscribe();
        _mainPersonDialogStartable.StartDialog(_dialog);
    }
}