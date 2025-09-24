using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class TextVariantVisual : MonoBehaviour, IChangeableVisualVariant
{
    private TMP_Text _textVariantVisual;

    private void Awake()
    {
        _textVariantVisual = GetComponent<TMP_Text>();
    }

    [SerializeField] private Color _defaultVariant;
    [SerializeField] private Color _activateVariant;

    public virtual void ChangeVisualToActivate() => SetActivateSprite();

    public virtual void ChangeVisualToDisactivate() => SetDisactivateSprite();

    private void SetDisactivateSprite() => _textVariantVisual.color = _defaultVariant;

    private void SetActivateSprite() => _textVariantVisual.color = _activateVariant;
}