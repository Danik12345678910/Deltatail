using System;
using UnityEngine;

public class NewInputSystemWriteAllDialogPage : IAllWritingPage
{
    public event System.Action OnWriteAllDialogPage;

    private InputSystem_Actions _inputs;

    public void Initialize(InputSystem_Actions inputs) => _inputs = inputs;     

    public void Enable()
    {
        _inputs.Dialog.WritingAllDialog.performed += _ => OnWriteAllDialogPage.Invoke();
    }
    //public void Disable() => _inputs.Disable();
}
