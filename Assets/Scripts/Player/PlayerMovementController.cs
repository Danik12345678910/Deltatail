using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private bool _moveIsLock;
    private EventBus _eventBus;
    
    [Header("Параметры передвижения игрока")]

    [SerializeField] private PlayerDataService _playerData;
    [SerializeField] private float _speed;

    [Space(), Header("Параметры анимации")]

    [SerializeField] private PlayerAnimation _playerAnimation;

    public void LockMove()
    {
        StopMove();
        _moveIsLock = true;
    }
    public void UnlockMove() => _moveIsLock = false;

    private void OnDialogStarted(DialogStartedSignal signal) => LockMove();
    private void OnDialogEnded(DialogEndedSignal signal) => UnlockMove();

    private void Start()
    {
        _eventBus = ServiceLocator.Current.GetService<EventBus>();

        _eventBus.Subscribe<DialogStartedSignal>(OnDialogStarted);
        _eventBus.Subscribe<DialogEndedSignal>(OnDialogEnded);
    }

    public void StopMove()
    {
        Move(Vector2.zero);
    }

    public void Move(Vector3 move)
    {
        if (!_moveIsLock)
        {
            //new PlayerMoveData();
            //_eventBus.Invoke(new PlayerMoveSignal(_playerData.Rigidbody2D.position);
            _playerData.Rigidbody2D.linearVelocity = move * _speed;
            _playerAnimation.AnimationMovement(move);
            //SetDirectionToMovement(move);
        }
    }

    private void OnDestroy()
    {
        _eventBus.Unsubscribe<DialogStartedSignal>(OnDialogStarted);
        _eventBus.Unsubscribe<DialogEndedSignal>(OnDialogEnded);
    }
    //private void SetDirectionToMovement(Vector2 movement)
    //{
    //    if(movement.magnitude != 0)
    //    {
    //        float xMove = Mathf.Abs(movement.x);
    //        float yMove = Mathf.Abs(movement.y);

    //        if(xMove > yMove) 
    //            CurrentDirection = movement.x > 0 ? MoveDirection.Right : MoveDirection.Left;
    //        else if(xMove > yMove)
    //            CurrentDirection = movement.y > 0 ? MoveDirection.Up : MoveDirection.Down;
    //    }
    //}

}