using UnityEngine;

[CreateAssetMenu(fileName = "AttackItemData", menuName = "Scriptable Objects/AttackItemData")]

public class AttackItemData : ItemData
{
    [field : SerializeField] public int Damage {  get; set; }

}