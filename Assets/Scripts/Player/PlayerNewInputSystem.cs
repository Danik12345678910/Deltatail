using UnityEngine;
[RequireComponent (typeof(PlayerMovementController))]

public class PlayerNewInputSystem : MonoBehaviour
{
    private InputSystem_Actions _action;
    private PlayerMovementController _controller;

    public void Initialize(InputSystem_Actions actions)
    {
        _controller = GetComponent<PlayerMovementController>();
        _action = actions;

        _action.Player.Movement.performed += _ => _controller.Move(_.ReadValue<Vector2>());
        _action.Player.Movement.canceled += _ => _controller.StopMove();
    }
}
