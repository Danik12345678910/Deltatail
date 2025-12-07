using UnityEngine;
using Zenject;

sealed public class DialogInputInstaller : MonoInstaller
{
    [SerializeField] private bool _onlySkipDialog;

    public override void InstallBindings()
    {
        if(!_onlySkipDialog)
            Container.Bind<IAllWritingPage>().To<NewInputSystemWriteAllDialogPage>().AsSingle();
        
        Container.Bind<ISkipDialogPage>().To<NewInputSystemSkipDialog>().AsSingle();
    }
}
