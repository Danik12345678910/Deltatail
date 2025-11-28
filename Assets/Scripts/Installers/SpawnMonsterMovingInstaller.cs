using UnityEngine;
using Zenject;

sealed public class SpawnMonsterMovingInstaller : MonoInstaller
{
    [SerializeReference, SubclassSelector] private IChanceCounterStartBattle _chanceCounter;
    public override void InstallBindings() => Container.BindInterfacesTo<SpawnMonsterMoving>().AsSingle().WithArguments(_chanceCounter);
}