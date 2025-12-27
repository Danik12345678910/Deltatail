using UnityEngine;
using Zenject;

public class PlayerDataServiceInstaller : MonoInstaller
{
    [SerializeField] private PlayerDataService _playerDataService;
    public override void InstallBindings()
    {
        Container.Bind<PlayerDataService>().FromInstance(_playerDataService).AsSingle();
    }
}