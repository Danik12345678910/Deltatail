public class MenuBattleState : BattleState
{
    private IActivatableVariantSwitch _activatableVariantSwitch;
    private IActionableTransitionState _transitionState;

    public MenuBattleState(IActivatableVariantSwitch activatableVariantSwitch, IActionableTransitionState transitionState)
    {
        _activatableVariantSwitch = activatableVariantSwitch;
        _transitionState = transitionState;
    }

    public override void Enter()
    {
        _transitionState.Action();
        _activatableVariantSwitch.ActivateVariantSwitcherController();
    }
}
