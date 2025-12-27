using System;
using UnityEngine;
using Zenject;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerDataService : MonoBehaviour
{
    public Transform Transform { get; private set; }
    public PlayerBattleData BattleData { get; private set; }
    public GameObject GameObject { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }

    //[Inject]
    //private void Initialize(PlayerBattleData battleData)
    //{
    //    BattleData = battleData;
    //}


    private void Awake()
    {
        Transform = transform;
        GameObject = gameObject;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
