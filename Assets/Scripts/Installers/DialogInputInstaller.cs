using System.Collections;
using UnityEngine;
using Zenject;

    public class DialogInputInstaller : MonoInstaller
    {
    public override void InstallBindings()
    {
        InputSystem_Actions inputActions = new InputSystem_Actions();
        inputActions.Enable();

        Container.BindInterfacesAndSelfTo<InputSystem_Actions>().FromInstance(inputActions).AsSingle();
        Container.Bind<IAllWritingPage>().To<NewInputSystemWriteAllDialogPage>().AsSingle().WithArguments(inputActions);
        Container.Bind<ISkipDialogPage>().To<NewInputSystemSkipDialog>().AsSingle().WithArguments(inputActions);

    }
    }
