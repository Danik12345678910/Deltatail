using UnityEngine;

abstract public class DialogData : ScriptableObject, IDialogData
{
    [field: SerializeField] public float SpeedTextWritingInSeconds { get; private set; }
    [field: SerializeField] public AudioDialogData Sound { get; private set; }
    [field: SerializeField] public string[] DialogPages { get; private set; }
}
