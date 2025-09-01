using UnityEngine;

public class VariantScop : MonoBehaviour
{
    [SerializeField] private Variant[] _variantsList;

    public void ActivateVariantSwitcherController()
    {
        var variantHandler = ServiceLocator.Current.GetService<VariantHandlerController>(); 
        variantHandler.StartHandler(_variantsList);
    }
}