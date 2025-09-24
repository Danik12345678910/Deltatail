using UnityEngine;

public class MovingToLocationSceneBootstrap : SceneBootstrap
{
    private NewInputSystemData _newInputSystemData;
    private string _name = "Dialog";
    [SerializeField] private MovingLocationDialogController _dialogController;
    [SerializeField] private VariantHandlerController _handlerController;
    [SerializeField] private PlayerNewInputSystem _playerNewInputSystem;

    protected override void Awake()
    {
        base.Awake();

        _newInputSystemData = new NewInputSystemData();
        _newInputSystemData.Enable();
        
        _dialogController.Initialize(_newInputSystemData.SkipDialog, _newInputSystemData.WriteAllDialogPage, _name);

        _playerNewInputSystem.Initialize(_newInputSystemData.InputActions);

        _handlerController.Initialize(_newInputSystemData.MovingVariant, _newInputSystemData.ActivateVariant);

        ServiceLocator.Current.Register<IInteractInput>((IInteractInput)_newInputSystemData.InputInteract);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        _newInputSystemData.Dispose();   
    }
}