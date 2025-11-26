using System;
using UnityEngine;

[Serializable]
public class DialogTextOnlyInteractionAction : InteractionActionEndingHandler
{
    [SerializeField] private DialogData _dialog;

    private event System.Action OnSubscribeHandler;
    private bool _isSubscribed;
    private IDialogStartable<DialogData> _dialogStartable;
    private EventBus _eventBus;

    public override event System.Action OnEndingAction;


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

    private void SubscribeHandler(DialogEndedSignal signal) => OnSubscribeHandler?.Invoke();

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
        _dialogStartable.StartDialog(_dialog);
    }
}