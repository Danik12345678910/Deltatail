sealed public class BattleController 
{
    readonly private FSM<BattleState> _fsmStateMap;
    readonly private BattleState[] _sequentialListBattleState;
    private int _nextBattleState;
    private int _countCycle = 0;

    public BattleController(FSM<BattleState> fsmStateInitialized, BattleState[] sequentialListBattleState)
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
}
