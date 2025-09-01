using UnityEngine;

[CreateAssetMenu(fileName = "MonsterBattleData", menuName = "Scriptable Objects/MonsterBattleData")]
public class MonsterBattleData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public AnimationClip Animation { get; private set; }
    [field: SerializeField] public AudioClip BattleClip { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public AttackData[] AttackDates { get; private set; }
}
