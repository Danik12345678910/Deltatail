using UnityEngine;

[CreateAssetMenu(fileName = "GroupMonsterBattleData", menuName = "Scriptable Objects/GroupMonsterBattleData")]
public class GroupMonsterBattleData : ScriptableObject
{
    public const int MAX_LENGHT = 3;
    [field: SerializeField] public AudioClip BattleClip { get; private set; }
    [field: SerializeField] public int DurationGroupAttack { get; private set; }
    [field : SerializeField] public MonsterBattleData[] Monsters { get; private set; }
    private void OnValidate()
    {
        if (Monsters.Length > MAX_LENGHT)
            Debug.LogError($"Массив {nameof(Monsters)} больше лимита!");
    }
}
