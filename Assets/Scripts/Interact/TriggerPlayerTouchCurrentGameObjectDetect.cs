using System;
using UnityEngine;

public class TriggerPlayerTouchCurrentGameObjectDetect : PlayerTouchCurrentGameObjectDetect
{
    public override bool IsTrigger => true;

    public override event System.Action OnCollisionEnter;
    public override event System.Action OnCollisionExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _playerGameObject)
            OnCollisionEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _playerGameObject)
            OnCollisionExit?.Invoke();
    }
}