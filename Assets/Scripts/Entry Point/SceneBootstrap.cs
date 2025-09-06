using UnityEngine;

public abstract class SceneBootstrap : MonoBehaviour 
{

    [Header("Сервисы передаваемые классу " + nameof(ServiceLocator))]
    [SerializeField] private MonoBehaviourService[] _monobehaviorServices;

    [SerializeReference, SubclassSelector] private IContextUpdater[] _contextUpdaters;

    protected void Awake()
    {
        ServiceLocator.Initialize();
        //var gameContext = FindFirstObjectByType<GameContext>();

        //ServiceLocator.Current.Register(gameContext);

        foreach (var service in _monobehaviorServices)
            ServiceLocator.Current.Register(service);

        //foreach (var contextUpdater in _contextUpdaters)
        //    contextUpdater.Initialize();

        //foreach (var contextUpdater in _contextUpdaters)
        //    contextUpdater.SubscribeToWriteContext();

        AdditionallyAwake();
    }

    protected void OnDestroy()
    {
        ServiceLocator.Disable();
        AdditionallyOnDestroy();

        foreach (var contextUpdater in _contextUpdaters)
            contextUpdater.UnsubscribeToWriteContext();
    }

    protected abstract void AdditionallyAwake();
    protected abstract void AdditionallyOnDestroy();
}