using UnityEngine;

[CreateAssetMenu(fileName = "MainDialogData", menuName = "Scriptable Objects/Dialog/MainDialogData")]
public class MainPersonDialogData : DialogData
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
}
