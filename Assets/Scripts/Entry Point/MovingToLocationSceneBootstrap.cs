using UnityEngine;

public class MovingToLocationSceneBootstrap : SceneBootstrap
{
    private NewInputSystemData _newInputSystemData;
    private string _name = "Dialog";
    [SerializeField] private DialogController _dialogController;
    [SerializeField] private VariantHandlerController _handlerController;
    [SerializeField] private PlayerNewInputSystem _playerNewInputSystem;

    protected override void AdditionallyAwake()
    {
        _newInputSystemData = new NewInputSystemData();
        _newInputSystemData.Enable();
        
        _dialogController.Initialize(_newInputSystemData.SkipDialog, _newInputSystemData.WriteAllDialogPage, _name);

        _playerNewInputSystem.Initialize(_newInputSystemData.InputActions);

        _handlerController.Initialize(_newInputSystemData.MovingVariant);

        ServiceLocator.Current.Register<IInteractInput>((IInteractInput)_newInputSystemData.InputInteract);
    }

    protected override void AdditionallyOnDestroy()
    {
        _newInputSystemData.Dispose();   
    }
}