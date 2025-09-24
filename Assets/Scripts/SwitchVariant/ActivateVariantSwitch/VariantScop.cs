using UnityEngine;

public class VariantScop : ActivateVariantSwitch
{
    [SerializeField] private Variant[] _variantsList;
    protected override Variant[] Variants => _variantsList;
}