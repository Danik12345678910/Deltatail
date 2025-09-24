using System;

public class NewInputSystemMovingVariant : IInputMovingVariant
{
    public event System.Action OnInputUp;
    public event System.Action OnInputDown;

    public void Initialize(InputSystem_Actions actions)
    {
        actions.VariantHandler.Up.performed += _ => OnInputUp?.Invoke();
        actions.VariantHandler.Down.performed += _ => OnInputDown?.Invoke();
    }
}