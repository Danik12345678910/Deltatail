using UnityEngine;

[System.Serializable]
public class ChancePercentStartBattleCounter : IChanceCounterStartBattle
{
    [SerializeField, Range(0f, 1f)] private float _chancePercentStartBattle = 0.01f;
    public bool IsStartBattle() => Random.Range(0f, 1f) <= _chancePercentStartBattle;
}