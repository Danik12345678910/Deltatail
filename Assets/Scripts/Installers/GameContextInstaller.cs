using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{
    public override void InstallBindings() => Container.Bind<GameContext>();
}