using UnityEngine;
[CreateAssetMenu(fileName = "MonsterPhaseBattleData", menuName = "Scriptable Objects/MonsterPhaseBattleData")]

public class MonsterPhaseBattleData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public DefaultMonsterBattleVisualData Visual { get; private set; }
    [field: SerializeField] public int StartHealth { get; private set; }
    [field: SerializeField] public AttackData[] Attacks { get; private set; }
    [field: SerializeReference, SubclassSelector] public IMonsterActionableOnTakeDamaged TakeDamageAction { get; private set; }
    [field: SerializeReference, SubclassSelector] public IMonsterActionableOnStart StartAction { get; private set; }
    [field: SerializeReference, SubclassSelector] public IMonsterActionableOnDie DieAction { get; private set; }
}