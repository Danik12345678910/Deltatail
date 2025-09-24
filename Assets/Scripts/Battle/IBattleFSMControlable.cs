public interface IBattleFSMControllable
{
    void Initialize(FSM<BattleState> fsm);
    void Update();
}