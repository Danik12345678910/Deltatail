using System;

public class StarterBattle : MonoBehaviourService
{
    public override Type ServiceType => GetType();
    public void StartBattle(MonsterBattleData monsterBattleData)
    {
        PlayerBattleData playerBattleData = ServiceLocator.Current.GetService<PlayerDataService>().BattleData;

    }
}