using UnityEngine;

abstract public class ActivateVariantSwitch : MonoBehaviour, IActivatableVariantSwitch
{
    abstract protected Variant[] Variants { get; }

    public void ActivateVariantSwitcherController()
    {
        var variantHandler = ServiceLocator.Current.GetService<VariantHandlerController>();
        variantHandler.StartHandler(Variants);
    }
}