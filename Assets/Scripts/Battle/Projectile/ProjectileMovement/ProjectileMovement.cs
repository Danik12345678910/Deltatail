using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private IProjectileMovementType _move;
    [SerializeReference] private float _speed;

    private void Update()
    {
        _move.Move();
    }

    public void Initialize(IProjectileMovementType move)
    {
        _move = move;
    }

}