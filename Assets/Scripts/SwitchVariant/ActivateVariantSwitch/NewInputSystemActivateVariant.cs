using System;

public class NewInputSystemActivateVariant : IInputActivateVariant
{
    private InputSystem_Actions _actions;
    public event System.Action OnInputActivated;

    public NewInputSystemActivateVariant(InputSystem_Actions actions)
    {
        this._actions = actions;
        _actions.VariantHandler.Enter.performed += _ => OnInputActivated?.Invoke();
    }
}