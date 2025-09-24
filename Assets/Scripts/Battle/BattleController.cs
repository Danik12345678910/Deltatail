using System;

public class BattleController : MonoBehaviourService
{
    private FSM<BattleState> _fsmStateMap;
    private int _nextBattleState;
    private int _countCycle;
    private BattleState[] _sequentialListBattleState;

    public void Initialize(FSM<BattleState> fsmStateInitialized, BattleState[] sequentialListBattleState)
    {
        _fsmStateMap = fsmStateInitialized;
        _sequentialListBattleState = sequentialListBattleState;
    }

    public void NextBattleState()
    {
        if (_nextBattleState > _sequentialListBattleState.Length - 1)
        {
            _countCycle++;
            _nextBattleState = 0;
        }

        var currentBattleState = _sequentialListBattleState[_nextBattleState];
        _fsmStateMap.SetCurrentState(currentBattleState.GetType());
        _nextBattleState++;
    }

    public override Type ServiceType => GetType();
}
