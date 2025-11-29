using UnityEngine;
using Zenject;

public class SceneTransitionControllerInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<SceneTransitionController>().AsSingle();
}