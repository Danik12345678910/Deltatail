using System;
using UnityEngine;

abstract public class PlayerTouchCurrentGameObjectDetect : MonoBehaviour
{
    abstract public event Action OnCollisionEnter;
    abstract public event Action OnCollisionExit;
    abstract public bool IsTrigger { get; }
    protected GameObject _playerGameObject;

    private void Awake()
    {
        if (gameObject.TryGetComponent(out Collider2D collider))
            collider.isTrigger = IsTrigger;
        else
            throw new NullReferenceException("На объекте отсутствует коллайдер");
    }

    protected void OnValidate()
    {
        if (GetComponent<Collider2D>() == null)
            Debug.LogError("На объекте отсутствует коллайдер");
    }

    public void Initialize(GameObject playerGameObject)
    {
        _playerGameObject = playerGameObject;
    }
}