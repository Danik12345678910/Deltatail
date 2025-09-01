using System;
using UnityEngine;

public class NewInputSystemInputInteract : IInteractInput
{
    public event Action OnInput;

    public void Initialize(InputSystem_Actions input)
    {
        input.Interaction.E.performed += _ => OnInput?.Invoke();
    }
}
