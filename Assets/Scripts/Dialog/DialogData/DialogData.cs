using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Objects/Dialog/DialogData")]
public class DialogData : ScriptableObject, IDialogData
{
    [field: SerializeField] public float SpeedTextWritingInSeconds { get; private set; }
    [field: SerializeField] public string[] DialogPages { get; private set; }
}
