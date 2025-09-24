using System;

public class NewInputSystemData : IDisposable
{
    public NewInputSystemInputInteract InputInteract { get; private set; }
    public NewInputSystemSkipDialog SkipDialog { get; private set; }
    public NewInputSystemMovingVariant MovingVariant { get; private set; }
    public NewInputSystemActivateVariant ActivateVariant { get; private set; }
    public NewInputSystemWriteAllDialogPage WriteAllDialogPage { get; private set; }
    public InputSystem_Actions InputActions { get; private set; }

    public void Enable()
    {
        InputActions = new InputSystem_Actions();
        InputActions.Enable();

        ActivateVariant = new NewInputSystemActivateVariant(InputActions);
        InputInteract = new NewInputSystemInputInteract();
        SkipDialog = new NewInputSystemSkipDialog();
        WriteAllDialogPage = new NewInputSystemWriteAllDialogPage();
        MovingVariant = new NewInputSystemMovingVariant();

        InputInteract.Initialize(InputActions);
        SkipDialog.Initialize(InputActions);
        WriteAllDialogPage.Initialize(InputActions);
        MovingVariant.Initialize(InputActions);

        SkipDialog.Enable();
        WriteAllDialogPage.Enable();
    }

    public void Dispose()
    {
        InputActions.Disable();
    }
}