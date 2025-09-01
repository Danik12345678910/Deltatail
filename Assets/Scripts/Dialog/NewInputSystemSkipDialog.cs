using System;
using UnityEngine;

public class NewInputSystemSkipDialog : ISkipDialogPage
{
    public event Action OnSkipDialogPage;
    private InputSystem_Actions _inputs;

    public void Initialize(InputSystem_Actions inputs) => _inputs = inputs;     

    public void Enable()
    {
        _inputs.Dialog.SkipPage.performed += _ => OnSkipDialogPage.Invoke();
    }
    //public void Disable() => _inputs.Disable();
}
