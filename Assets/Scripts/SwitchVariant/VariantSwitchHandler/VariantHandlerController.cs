using System;

public class VariantHandlerController : MonoBehaviourService
{
    public override Type ServiceType => GetType();

    private Variant[] _listVariants;
    private Variant _currentVariant;
    private IInputMovingVariant _movingVariant;
    private IInputActivateVariant _activateVariant;
    private int _currentVariantIndex;
    private bool _isEnable;

    public void Initialize(IInputMovingVariant moving, IInputActivateVariant activate)
    {
        _movingVariant = moving;
        _activateVariant = activate;

        _activateVariant.OnInputActivated += Activate;

        _movingVariant.OnInputDown += DownVariant;
        _movingVariant.OnInputUp += UpVariant;
    }

    private void UpVariant()
    {
        if (_isEnable)
        {

            if (_listVariants.Length < _currentVariantIndex)
                _currentVariantIndex++;

            SetCurrentVariant();
        }
    }

    private void DownVariant()
    {
        if (_isEnable)
        {

            if (_currentVariantIndex < 0)
                _currentVariantIndex--;
            SetCurrentVariant();
        }
    }

    private void Activate()
    {
        if (_isEnable)
        {
            _currentVariant.ActivateAction();
            EndHandler();
        }
    }

    public void StartHandler(Variant[] listVariant)
    {
        _currentVariantIndex = 0;
        _listVariants = listVariant;
        SetCurrentVariant();
        _isEnable = true;
    }


    private void SetCurrentVariant()
    {
        if (_currentVariant != null)
            _currentVariant.ExitCurrentVariant();

        _currentVariant = _listVariants[_currentVariantIndex];
        _currentVariant.EnterCurrentVariant();
    }

    public void EndHandler()
    {
        _isEnable = false;
    }

    private void OnDestroy()
    {
        _movingVariant.OnInputDown += DownVariant;
        _movingVariant.OnInputUp += UpVariant;
        _activateVariant.OnInputActivated -= Activate;
    }
}
