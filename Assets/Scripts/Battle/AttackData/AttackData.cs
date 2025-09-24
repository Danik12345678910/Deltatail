using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/AttackData")]
public class AttackData : ScriptableObject
{
    [field: SerializeReference, SubclassSelector] public IAttackPattern Pattern { get; private set; }
    //[field: SerializeField] public int DurationAttack { get; private set; }
}