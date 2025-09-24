using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterBattle : MonoBehaviourService
{
    [SerializeField] private Scene _battleScene;
    [SerializeField] private int _maxCount;
    public override Type ServiceType => GetType();
    public void StartBattle(GroupMonsterBattleData monsterBattleData)
    {
        if (monsterBattleData.Monsters.Length > _maxCount)
            throw new InvalidOperationException("Монстров больше максимального количества. Максимальное количество:" + _maxCount);

        PlayerBattleData playerBattleData = ServiceLocator.Current.GetService<PlayerDataService>().BattleData;
        GameContext context = ServiceLocator.Current.GetService<GameContext>();
        SceneTransitionController sceneTransitionController = ServiceLocator.Current.GetService<SceneTransitionController>();

        BattleStartedContextData battleStartedContext = new BattleStartedContextData(new BattleData(playerBattleData, monsterBattleData));

        context.WriteContext(battleStartedContext);
        sceneTransitionController.Transition(_battleScene);
    }
}