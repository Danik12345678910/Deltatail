public class DefaultInteractGameObject : InteractGameObject
{
    protected override void Start()
    {
        base.Start();

        _touchDetect.OnCollisionEnter += Interact;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        _touchDetect.OnCollisionEnter -= Interact;
    }
}