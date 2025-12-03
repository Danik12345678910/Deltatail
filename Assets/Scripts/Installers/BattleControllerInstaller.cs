using Zenject;
//НУЖНО ДОДЕЛАТЬ КОД!!!
public class BattleControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BattleState[] allState = new BattleState[0];
        FSM<BattleState> _fsm = new FSM<BattleState>();
        _fsm.Initialize(allState);
        Container.Bind<BattleController>().AsSingle().WithArguments(allState, _fsm);
    }
}