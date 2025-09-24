using UnityEngine;

public class Monster : MonoBehaviour
{
    private MonsterPhaseBattleDynamicData _currentPhase;

    public void Initialize(MonsterPhaseBattleDynamicData startPhase)
    {
        _currentPhase = startPhase;
        _currentPhase.Health.OnDie += _currentPhase.DieAction.Action;
        _currentPhase.StartAction.Action();
    }

    public void TakeDamage(int damage)
    {
        _currentPhase.Health.Damage(damage);

        if(_currentPhase.Health.IsAlive) 
            _currentPhase.TakeDamageAction.Action();
    }

    public void NewPhase(MonsterPhaseBattleDynamicData data)
    {
        _currentPhase.Health.OnDie -= _currentPhase.DieAction.Action;
        _currentPhase = data;
        _currentPhase.StartAction.Action();
        _currentPhase.Health.OnDie += _currentPhase.DieAction.Action;
    }

    private void OnDestroy()
    {
        _currentPhase.Health.OnDie -= _currentPhase.DieAction.Action;
    }
}
