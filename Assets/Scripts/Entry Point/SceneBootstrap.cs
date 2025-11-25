using UnityEngine;

public abstract class SceneBootstrap : MonoBehaviour
{

    [Header("Сервисы передаваемые классу " + nameof(ServiceLocator))]
    [SerializeField] private MonoBehaviourService[] _monobehaviorServices;

    [SerializeReference, SubclassSelector] private IContextUpdater[] _contextUpdaters;

    protected virtual void Awake()
    {
        ServiceLocator.Initialize();

        if (_contextUpdaters != null)
        {
            var eventBus = FindFirstObjectByType<EventBus>();

            //foreach (var contextUpdater in _contextUpdaters)
            //    contextUpdater.Initialize(eventBus, gameContext);

            foreach (var contextUpdater in _contextUpdaters)
                contextUpdater.SubscribeToWriteContext();
        }

        foreach (var service in _monobehaviorServices)
            ServiceLocator.Current.Register(service);
    }

    protected virtual void OnDestroy()
    {
        ServiceLocator.Disable();

        if(_contextUpdaters != null)
            foreach (var contextUpdater in _contextUpdaters)
                contextUpdater.UnsubscribeToWriteContext();
    }
}