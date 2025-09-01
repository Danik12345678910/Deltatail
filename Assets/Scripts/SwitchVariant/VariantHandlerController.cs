using System;

public class VariantHandlerController : MonoBehaviourService
{
    public override Type ServiceType => GetType();

    private Variant[] _listVariants;
    private Variant _currentVariant;
    private IInputMovingVariant _movingVariant;
    private int _currentVariantIndex;
    private bool _isEnable;

    public void Initialize(IInputMovingVariant moving)
    {
        _movingVariant = moving;

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
        _currentVariant.ActivateAction();
        EndHandler();
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
}
