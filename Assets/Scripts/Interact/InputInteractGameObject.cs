public class InputInteractGameObject : InteractGameObject
{
    private IInteractInput _interactInput;
    private bool _isPlayerCollision;

    private void SetIsPlayerCollision()
    {
        _isPlayerCollision = true;
    }

    private void InteractCollisionPlayerCheck()
    {
        if (_isPlayerCollision)
            Interact();
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

    protected override void Start()
    {
        base.Start();

        _interactInput = ServiceLocator.Current.GetService<IInteractInput>();
        _interactInput.OnInput += InteractCollisionPlayerCheck;

        _touchDetect.OnCollisionEnter += SetIsPlayerCollision;
        _touchDetect.OnCollisionExit += UnsetIsPlayerCollision;
    }
}