using System;
using UnityEngine;

public class CollisionPlayerTouchCurrentGameObjectDetect : PlayerTouchCurrentGameObjectDetect
{
    public override bool IsTrigger => false;

    public override event System.Action OnCollisionEnter;
    public override event System.Action OnCollisionExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _playerGameObject)
            OnCollisionEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == _playerGameObject)
            OnCollisionExit?.Invoke();
    }
}