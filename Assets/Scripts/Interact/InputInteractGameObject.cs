using System.Runtime.InteropServices;
using Zenject;

public class InputInteractGameObject : InteractGameObject
{
    private IInteractInput _interactInput;
    private bool _isPlayerCollision;

    [Inject]
    private void Construct(IInteractInput interactInput)
    {
        _interactInput = interactInput;
        _interactInput.OnInput += InteractCollisionPlayerCheck;
        _touchDetect.OnCollisionEnter += SetIsPlayerCollision;
        _touchDetect.OnCollisionExit += UnsetIsPlayerCollision;
    }
    private void SetIsPlayerCollision()
    {
        _isPlayerCollision = true;
    }

    private void InteractCollisionPlayerCheck()
    {
        if (_isPlayerCollision)
        {
            Interact();
            _isPlayerCollision = false;
        }
    }

    private void UnsetIsPlayerCollision()
    {
        _isPlayerCollision = false;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        _interactInput.OnInput -= InteractCollisionPlayerCheck;
        _touchDetect.OnCollisionEnter -= SetIsPlayerCollision;
        _touchDetect.OnCollisionExit -= UnsetIsPlayerCollision;
    }
}