using UnityEngine;

public class SpawnMonsterMoving : MonoBehaviour
{
    [SerializeReference, SubclassSelector]private IChanceCounterStartBattle _chanceCounter;
    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Current.GetService<EventBus>();   
        _bus.Subscribe<PlayerMoveSignal>(StartingBattleCheck);
    }

    private void OnDestroy()
    {
        _bus.Unsubscribe<PlayerMoveSignal>(StartingBattleCheck);    
    }

    private void StartingBattleCheck(PlayerMoveSignal signal)
    {
        if(_chanceCounter.IsStartBattle())
        {
            Debug.Log("Битва началась!");
        }
    }
}
