using UnityEngine;
using Zenject;

abstract public class ActivateVariantSwitch : MonoBehaviour, IActivatableVariantSwitch
{
    abstract protected Variant[] Variants { get; }
    
    private VariantHandlerController _controller;

    [Inject]
    private void Initialize(VariantHandlerController controller) => _controller = controller;

    public void ActivateVariantSwitcherController() => _controller.StartHandler(Variants);
}