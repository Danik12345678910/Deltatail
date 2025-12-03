using UnityEngine;
using Zenject;

public class InteractInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInteractInput>().To<NewInputSystemInputInteract>().AsSingle();
    }
}