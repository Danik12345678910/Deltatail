using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private DialogController _dialogController;
    [SerializeField] private VariantHandlerController _handlerController;
    [SerializeField] private PlayerNewInputSystem _playerNewInputSystem;
    private NewInputSystemData _newInputSystemData;
    private string _name = "Dialog";

    private void Awake()
    {
        _newInputSystemData = new NewInputSystemData();
        _newInputSystemData.Enable();
        
        _dialogController.Initialize(_newInputSystemData.SkipDialog, _newInputSystemData.WriteAllDialogPage, _name);

        _playerNewInputSystem.Initialize(_newInputSystemData.InputActions);

        _handlerController.Initialize(_newInputSystemData.MovingVariant);

        InteractGameObject[] interactGameObjects = FindObjectsByType<InteractGameObject>(FindObjectsSortMode.None);
        foreach (var gameObject in interactGameObjects)
            gameObject.Initialize(_newInputSystemData.InputInteract);
    }

    private void OnDestroy() 
    {
     _newInputSystemData.Dispose();   
    }
}
