using UnityEngine;

[CreateAssetMenu(fileName = "MainDialogData", menuName = "Scriptable Objects/Dialog/MainDialogData")]
sealed public class MainPersonDialogData : DialogData
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public AudioDialogData Sound { get; private set; }
}
