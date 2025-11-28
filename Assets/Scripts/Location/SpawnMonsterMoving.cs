using System;
using UnityEngine;
using Zenject;

sealed public class SpawnMonsterMoving : IDisposable
{
    readonly private IChanceCounterStartBattle _chanceCounter;
    readonly private EventBus _bus;
    private bool _isSubscribe = false;

    public void Dispose()
    {
        if (_isSubscribe)
            _bus.Unsubscribe<PlayerMoveSignal>(StartingBattleCheck);
    }

    public SpawnMonsterMoving(EventBus eventBus, IChanceCounterStartBattle chanceCounterStartBattle)
    {
        _bus = eventBus;
        _chanceCounter = chanceCounterStartBattle;

        _bus.Subscribe<PlayerMoveSignal>(StartingBattleCheck);
        _isSubscribe = true;
    }

    private void StartingBattleCheck(PlayerMoveSignal signal)
    {
        if(_chanceCounter.IsStartBattle())
        {
            Debug.Log("Битва началась!");
        }
    }
}
