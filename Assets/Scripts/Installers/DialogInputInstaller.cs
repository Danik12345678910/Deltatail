using System.Collections;
using UnityEngine;
using Zenject;

public class DialogInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IAllWritingPage>().To<NewInputSystemWriteAllDialogPage>().AsSingle().WithArguments(inputActions);
        Container.Bind<ISkipDialogPage>().To<NewInputSystemSkipDialog>().AsSingle().WithArguments(inputActions);

    }
}
