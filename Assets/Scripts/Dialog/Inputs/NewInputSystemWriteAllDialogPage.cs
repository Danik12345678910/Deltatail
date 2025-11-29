sealed public class NewInputSystemWriteAllDialogPage : IAllWritingPage
{
    public event System.Action OnWriteAllDialogPage;

    readonly private InputSystem_Actions _inputs;

    public NewInputSystemWriteAllDialogPage(InputSystem_Actions inputs) => _inputs = inputs;     

    public void Enable() => _inputs.Dialog.WritingAllDialog.performed += _ => OnWriteAllDialogPage.Invoke();
}
