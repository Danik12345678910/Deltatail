using System;
using UnityEngine;

sealed public class NewInputSystemSkipDialog : ISkipDialogPage
{
    public event System.Action OnSkipDialogPage;
    readonly private InputSystem_Actions _inputs;

    public NewInputSystemSkipDialog(InputSystem_Actions inputs) => _inputs = inputs;     

    public void Enable() => _inputs.Dialog.SkipPage.performed += _ => OnSkipDialogPage.Invoke();
}
