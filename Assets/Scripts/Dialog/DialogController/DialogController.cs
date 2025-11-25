using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

sealed public class DialogController : IDialogStartable<MainPersonDialogData>, IDialogStartable<DialogData>, IDialogStartable<DictorDialogData>
{
    readonly private ControllerCoroutine _controllerCoroutine;
    readonly private GameObject _dialogBar;
    readonly private Image _icon;
    readonly private TMP_Text _mainPersonDialogText;
    readonly private TMP_Text _anotherPersonDialogText;

    readonly private char _alwaysStartingPrefix;
    readonly private char _dictorLeftPrefix;
    readonly private char _dictorRightPrefix;

    readonly private AudioClip[] _baseClips;

    private AudioClip RandomBaseClip => _baseClips[UnityEngine.Random.Range(0, _baseClips.Length)];
    private AudioContainer _dialogAudio;

    private DialogData _currentDialog;
    private bool _isContinuationOfDialogueNow;
    private bool _isEndingPageDialog;
    private int _currentPageIndex;

    private string _text;

    readonly private ISkipDialogPage _currentSkipDialogPage;
    readonly private IAllWritingPage _allWritingPage;

    readonly private EventBus _eventBus;

    private Coroutine _writingCoroutineReference;

    //protected event Action OnStartedDialog;

    public DialogController(DialogControllerConfig config, ControllerCoroutine controllerCoroutine, EventBus eventBus, ISkipDialogPage skipDialogPage, IAllWritingPage allWritingPage)
    {
        _dialogBar = config.dialogBar;
        _icon = config.icon;
        _mainPersonDialogText = config.mainPersonDialogText;
        _anotherPersonDialogText = config.anotherPersonDialogText;
        _baseClips = config.baseClips;
        _alwaysStartingPrefix = config.alwaysStartingPrefix;
        _dictorRightPrefix = config.dictorRightPrefix;
        _dictorLeftPrefix = config.dictorLeftPrefix;

        _controllerCoroutine = controllerCoroutine;
        _eventBus = eventBus;
        _currentSkipDialogPage = skipDialogPage;
        _allWritingPage = allWritingPage;

        _currentSkipDialogPage.OnSkipDialogPage += SkipDialogPage;
        _allWritingPage.OnWriteAllDialogPage += WriteAllPage;
    }


    private void Awake()
    {
        ResetDialog();
        DisactivateDialogBar();
    }

    private void WriteAllPage()
    {
        if (_isContinuationOfDialogueNow && !_isEndingPageDialog)
        {
            _anotherPersonDialogText.text = _text;
            _isEndingPageDialog = true;
            _controllerCoroutine.StopCoroutine(_writingCoroutineReference);
            _writingCoroutineReference = null;
        }
    }
    private void SkipDialogPage()
    {
        if (_isContinuationOfDialogueNow && _isEndingPageDialog)
        {
            _currentPageIndex++;
            if (_currentPageIndex < _currentDialog.DialogPages.Length)
                SetDialogInDialogTextCurrentPage();
            else
                EndDialog();
        }
    }

    private void ChangeSprite(in Sprite sprite) => _icon.sprite = sprite;
    private void ChangeAlpha(in int alpha)
    {
        Color color = _icon.color;
        color.a = alpha;
        _icon.color = color;
    }

    public void StartDialog(MainPersonDialogData dialog)
    {
        if (!_isContinuationOfDialogueNow)
        {
            _currentPageIndex = 0;
            _currentDialog = dialog;

            Validate();

            //OnStartedDialog?.Invoke();

            _isContinuationOfDialogueNow = true;
            _eventBus.Invoke(new DialogStartedSignal());

            ActivateDialogBar();
            SetDialogInDialogTextCurrentPage();
            ChangeAlpha(1);
            ChangeSprite(dialog.Sprite);
        }
    }

    private void Validate()
    {
        if (_dialogBar == null)
            throw new InvalidOperationException("Диалоговая панель (_dialogBar) не назначена.");
        if (_currentDialog == null)
            throw new ArgumentNullException(nameof(_currentDialog), "Данные диалога равны null.");
        if (_currentDialog.DialogPages == null)
            throw new NullReferenceException("Массив страниц диалога равен null.");
        if (_currentDialog.DialogPages.Length == 0)
            throw new InvalidOperationException("В диалоге нет страниц.");

        for (int i = 0; i < _currentDialog.DialogPages.Length; i++)
        {
            if (_currentDialog.DialogPages[i] == null)
                throw new NullReferenceException($"Страница диалога с индексом {i} равна null.");
        }
    }

    private void EndDialog()
    {
        ResetDialog();
        _eventBus.Invoke(new DialogEndedSignal());
    }

    private void ResetDialog()
    {
        DisactivateDialogBar();
        ChangeAlpha(0);
        ResetAllText();

        _isContinuationOfDialogueNow = false;

        if (_writingCoroutineReference != null)
            _controllerCoroutine.StopCoroutine(_writingCoroutineReference);
    }

    private void ResetAllText()
    {
        const string EMPTY = "";
        _anotherPersonDialogText.text = EMPTY;
        _mainPersonDialogText.text = EMPTY;
    }

    private void SetText()
    {
        bool isDictor = _currentDialog is DictorDialogData;
        _text = _alwaysStartingPrefix + " " + (isDictor ? _dictorLeftPrefix.ToString() : "") + _currentDialog.DialogPages[_currentPageIndex] + (isDictor ? _dictorRightPrefix.ToString() : "");
    }

    private void SetDialogInDialogTextCurrentPage()
    {
        if (_writingCoroutineReference != null)
            _controllerCoroutine.StopCoroutine(_writingCoroutineReference);

        SetText();
        _writingCoroutineReference = _controllerCoroutine.StartCoroutine(WritingCoroutine());
    }

    private IEnumerator WritingCoroutine()
    {
        _isEndingPageDialog = false;

        string currentText = string.Empty;

        for (int i = 0; i < _text.Length; i++)
        {
            currentText += _text[i];

            _dialogAudio.Audio.ChangePitch(UnityEngine.Random.Range(0.9f, 0.95f));
            _dialogAudio.Audio.PlayOneShot(RandomBaseClip);

            if (_currentDialog is MainPersonDialogData)
                _mainPersonDialogText.text = currentText;
            else
                _anotherPersonDialogText.text = currentText;

            yield return new WaitForSeconds(_currentDialog.SpeedTextWritingInSeconds);
        }

        _isEndingPageDialog = true;
    }

    private void ActivateDialogBar() => _dialogBar.SetActive(true);
    private void DisactivateDialogBar() => _dialogBar.SetActive(false);

    private void OnDestroy()
    {
        if (_currentSkipDialogPage != null)
            _currentSkipDialogPage.OnSkipDialogPage -= SkipDialogPage;

        if (_allWritingPage != null)
            _allWritingPage.OnWriteAllDialogPage -= WriteAllPage;
    }

    public void StartDialog(DialogData data)
    {
        if (!_isContinuationOfDialogueNow)
        {
            _currentPageIndex = 0;
            _currentDialog = data;

            Validate();

            //OnStartedDialog?.Invoke();

            _isContinuationOfDialogueNow = true;
            _eventBus.Invoke(new DialogStartedSignal());

            ActivateDialogBar();
            SetDialogInDialogTextCurrentPage();
        }
    }

    public void StartDialog(DictorDialogData data)
    {
        if (!_isContinuationOfDialogueNow)
        {
            _currentPageIndex = 0;
            _currentDialog = data;

            Validate();

            //OnStartedDialog?.Invoke();

            _isContinuationOfDialogueNow = true;
            _eventBus.Invoke(new DialogStartedSignal());

            ActivateDialogBar();
            SetDialogInDialogTextCurrentPage();
        }
    }
}

public struct DialogControllerConfig
{
    public readonly GameObject dialogBar;
    public readonly Image icon;
    public readonly TMP_Text mainPersonDialogText;
    public readonly TMP_Text anotherPersonDialogText;
    public readonly AudioClip[] baseClips;
    public readonly char alwaysStartingPrefix;
    public readonly char dictorRightPrefix;
    public readonly char dictorLeftPrefix;

    public DialogControllerConfig(
        GameObject dialogBar,
        Image icon,
        TMP_Text mainPersonDialogText,
        TMP_Text anotherPersonDialogText,
        AudioClip[] baseClips,
        char alwaysStartingPrefix = '*',
        char dictorRightPrefix = ')',
        char dictorLeftPrefix = '(')
    {
        this.dialogBar = dialogBar;
        this.icon = icon;
        this.mainPersonDialogText = mainPersonDialogText;
        this.anotherPersonDialogText = anotherPersonDialogText;
        this.baseClips = baseClips;
        this.alwaysStartingPrefix = alwaysStartingPrefix;
        this.dictorRightPrefix = dictorRightPrefix;
        this.dictorLeftPrefix = dictorLeftPrefix;
    }
}