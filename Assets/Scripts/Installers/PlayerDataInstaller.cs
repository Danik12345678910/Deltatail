using UnityEngine;
using Zenject;

public sealed class PlayerDataInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerDataService;
    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerDataService).AsSingle();   
    }
}