using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Objects/DialogData")]
public class DialogData : ScriptableObject
{
    [field : SerializeField] public Sprite Sprite { get; private set; }
    [field : SerializeField] public float SpeedTextWritingInSeconds { get; private set; }
    [field : SerializeField] public AudioDialogData Sound { get; private set; }
    [field : SerializeField] public string[] DialogPages { get; private set; }
}
