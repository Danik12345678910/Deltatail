using UnityEngine;
using Zenject;

public sealed class EventBusInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Инциализирован!");
        Container.Bind<EventBus>().AsSingle();
    }
}