using UnityEngine;

[CreateAssetMenu(fileName = "BattleDialogData", menuName = "Scriptable Objects/Dialog/BattleDialogData")]


sealed public class BattleDialogData : DialogData
{
    [field : SerializeField] public AudioDialogData Sound {  get; private set; }
}