using UnityEngine;

public class BattleSceneBootstrap : SceneBootstrap
{
    [SerializeField] private Monster[] _monsters;
    protected override void Awake()
    {
        base.Awake();


    }
}