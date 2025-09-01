using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MovementInteractionAction : InteractionActionEndingHandler
{
    public override event Action OnEndingAction;
    [SerializeField] private Vector2 _targetMovement;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    private Vector2 _oldPosition;
    private StarterCoroutine _starterCoroutine;

    public override void Action()
    {
        _oldPosition = _transform.position;
        _starterCoroutine = ServiceLocator.Current.GetService<StarterCoroutine>();
        _starterCoroutine.StartCoroutine(MoveCoroutine());
    }

    private void Move() => _transform.position = Vector2.MoveTowards(_transform.position, _targetMovement + _oldPosition, _speed * Time.deltaTime);

    private IEnumerator MoveCoroutine()
    {
        while (Vector2.Distance((Vector2)_transform.position, _oldPosition + _targetMovement) > 0.01f)
        {
            Move();
            yield return null;
        }
        OnEndingAction?.Invoke();
    }
}