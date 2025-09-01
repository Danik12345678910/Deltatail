using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerDataService : MonoBehaviourService
{
    public override Type ServiceType => GetType();

    public Transform Transform { get; private set; }
    public PlayerBattleData BattleData { get; private set; }
    public GameObject GameObject { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Transform = transform;
        GameObject = gameObject;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
