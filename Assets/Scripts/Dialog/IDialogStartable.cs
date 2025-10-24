public interface IDialogStartable<DialogData> where DialogData : IDialogData
{
    void StartDialog(DialogData data);
}
