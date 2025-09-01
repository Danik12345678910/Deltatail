using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class ImageVariantVisual : MonoBehaviour, IChangeableVisualVariant
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    [SerializeField] private Sprite _activateSprite;
    [SerializeField] private Sprite _disactivateSprite;
    
    public void ChangeVisualToActivate() => SetActivateSprite();
    public void ChangeVisualToDisactivate() => SetDisactivateSprite();

    private void SetDisactivateSprite() => _image.sprite = _disactivateSprite;

    private void SetActivateSprite() => _image.sprite = _activateSprite;
}