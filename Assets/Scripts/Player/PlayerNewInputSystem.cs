using UnityEngine;
using Zenject;
[RequireComponent (typeof(PlayerMovementController))]

sealed public class PlayerNewInputSystem : MonoBehaviour
{
    private InputSystem_Actions _action;
    private PlayerMovementController _controller;

    [Inject]
    private void Initialize(InputSystem_Actions actions)
    {
        _action = actions;

        _action.Player.Movement.performed += _ => _controller.Move(_.ReadValue<Vector2>());
        _action.Player.Movement.canceled += _ => _controller.StopMove();
    }

    private void Awake() => _controller = GetComponent<PlayerMovementController>();
}
