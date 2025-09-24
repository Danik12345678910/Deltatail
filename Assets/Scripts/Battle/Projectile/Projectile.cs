using UnityEngine;
[RequireComponent(typeof(TriggerPlayerTouchCurrentGameObjectDetect))]
public class Projectile : Pool
{
    [SerializeField, Min(0)] private int _damage;
    private PlayerTouchCurrentGameObjectDetect _playerTouchDetect;

    private void Awake()
    {
        _playerTouchDetect = GetComponent<PlayerTouchCurrentGameObjectDetect>();
    }

    public void Initialize(GameObject player)
    {
        _playerTouchDetect.Initialize(player);

    }
}