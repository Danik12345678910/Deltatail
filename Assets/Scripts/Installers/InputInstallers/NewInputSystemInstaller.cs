using Zenject;

sealed public class NewInputSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InputSystem_Actions inputActions = new InputSystem_Actions();
        inputActions.Enable();

        Container.BindInterfacesAndSelfTo<InputSystem_Actions>().FromInstance(inputActions).AsSingle();
    }
}