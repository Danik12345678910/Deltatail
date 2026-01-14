using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class DialogControllerInstaller : MonoInstaller
    {
        [Header("Ссылки на UI")]
        [SerializeField] private GameObject _dialogBar;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _mainPersonDialogText;
        [SerializeField] private TMP_Text _anotherPersonDialogText;

        [Space]

        [Header("Параметры")]

        [SerializeField] private char _alwaysStartingPrefix = '*';

        [SerializeField] private char _dictorLeftPrefix = '(';
        [SerializeField] private char _dictorRightPrefix = ')';

        [SerializeField] private AudioClip[] _baseClips;
        public override void InstallBindings()
        {
            DialogControllerConfig config = new DialogControllerConfig 
            (
                _dialogBar,
                _icon,
                _mainPersonDialogText,
                _anotherPersonDialogText,
                _baseClips,
                _alwaysStartingPrefix,
                _dictorLeftPrefix,
                _dictorRightPrefix
            );
            Container.BindInterfacesTo<DialogController>().AsSingle().WithArguments(config);
        }
    }
}