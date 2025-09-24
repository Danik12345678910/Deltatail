using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMonsterBattleVisualData", menuName = "Scriptable Objects/DefaultMonsterBattleVisualData")]
public class DefaultMonsterBattleVisualData : ScriptableObject
{
    //[field : SerializeField] public AnimationClip TakeDamageAnimation { get; private set; }
    //[field: SerializeField] public AnimationClip DeathAnimation { get; private set; }
    //[field: SerializeField] public AnimationClip AttackingAnimation { get; private set; }
    [field: SerializeField] public AnimationClip DefaultAnimation { get; private set; }
}
