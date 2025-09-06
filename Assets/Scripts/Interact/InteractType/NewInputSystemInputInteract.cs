using System;
using UnityEngine;

public class NewInputSystemInputInteract : IInteractInput, IService
{
    public Type ServiceType => typeof(IInteractInput);

    public event Action OnInput;

    public void Initialize(InputSystem_Actions input)
    {
        input.Interaction.E.performed += _ => OnInput?.Invoke();
    }
}
