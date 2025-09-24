using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "Scriptable Objects/Monsters")]
public class MonsterBattleData : ScriptableObject
{
    [field : SerializeReference, SubclassSelector] public MonsterPhaseBattleData[] Phases {  get; private set; }
    [field: SerializeReference, SubclassSelector] public IIsTransitionNextPhaseCondition[] condition { get; private set; }
}
