using UnityEngine;

public class ServiceLocatorBootstrap : MonoBehaviour
{
    [SerializeField] private MonoBehaviourService[] _services;

    private void Awake()
    {
        ServiceLocator.Initialize();

        foreach (var service in _services)
            ServiceLocator.Current.Register(service);
    }
}
