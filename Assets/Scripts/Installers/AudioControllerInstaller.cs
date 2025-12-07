using UnityEngine;
using Zenject;

sealed public class AudioControllerInstaller : MonoInstaller
{
    [SerializeField] private AudioController _controller;
    public override void InstallBindings()
    {
        Container.Bind<AudioController>().FromInstance(_controller).AsSingle();
    }
}