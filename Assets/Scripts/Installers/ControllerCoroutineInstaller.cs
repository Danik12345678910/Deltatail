using UnityEngine;
using Zenject;

sealed public class ControllerCoroutineInstaller : MonoInstaller
{
    [SerializeField] private ControllerCoroutine _controllerCoroutine;
    public override void InstallBindings() => Container.Bind<ControllerCoroutine>().FromInstance(_controllerCoroutine).AsSingle();
}