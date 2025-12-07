using System;
using UnityEngine;
using UnityEngine.SceneManagement;

sealed public class StarterBattle
{
    readonly private Scene _battleScene;
    readonly private int _maxCount;
    readonly private GameContext _gameContext;
    readonly private SceneTransitionController _sceneTransitionController;

    public StarterBattle(Scene battleScene, int maxCount, GameContext gameContext, SceneTransitionController transitionController)
    {
        _battleScene = battleScene;
        _maxCount = maxCount;
        _gameContext = gameContext;
        _sceneTransitionController = transitionController;
    }

    public void StartBattle(in GroupMonsterBattleData monsterBattleData)
    {
        if (monsterBattleData.Monsters.Length > _maxCount)
            throw new InvalidOperationException("Монстров больше максимального количества. Максимальное количество:" + _maxCount);

        //PlayerBattleData playerBattleData = ServiceLocator.Current.GetService<PlayerDataService>().BattleData;

        //BattleStartedContextData battleStartedContext = new BattleStartedContextData(new BattleData(playerBattleData, monsterBattleData));

        //_gameContext.WriteContext(battleStartedContext);
        _sceneTransitionController.Transition(_battleScene);
    }
}