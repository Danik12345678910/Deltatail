using UnityEngine;

abstract public class Variant : MonoBehaviour, IVariantActivatableAction
{
    protected IChangeableVisualVariant Visual { set; private get; }
    [field : SerializeField] public int PositionArray { get; private set; }

    public abstract void ActivateAction();

    public void EnterCurrentVariant()
    {
        Visual.ChangeVisualToActivate();
    }

    public void ExitCurrentVariant()
    {
        Visual.ChangeVisualToDisactivate();
    }
}