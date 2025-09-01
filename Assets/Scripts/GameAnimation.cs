using UnityEngine;
[RequireComponent (typeof(Animator))]

abstract public class GameAnimation : MonoBehaviour
{
    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}