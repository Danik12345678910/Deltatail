using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BattleDialogController : IDialogStartable<BattleDialogData>, IStartable
{
    [SerializeField] private GameObject _dialogBar;
    [SerializeField] private TMP_Text _dialogText;
    private Audio _dialogAudio;

    private BattleDialogData _currentDialog;
    private bool _isContinuationOfDialogueNow;
    private bool _isEndingPageDialog;
    private int _currentPageIndex;

    readonly private ISkipDialogPage _currentSkipDialogPage;
    readonly private IAllWritingPage _allWritingPage;

    readonly private EventBus _eventBus;
    readonly private ControllerCoroutine _controllerCoroutine;

    private Coroutine _writingCoroutineReference;

    public int Priority => throw new NotImplementedException();

    //protected event Action OnStartedDialog;



    public BattleDialogController(ISkipDialogPage skipDialog, IAllWritingPage allWritingPage, EventBus eventBus, ControllerCoroutine controllerCoroutine, in string audioKey)
    {
        _currentSkipDialogPage = skipDialog;
        _allWritingPage = allWritingPage;
        _eventBus = eventBus;
        _controllerCoroutine = controllerCoroutine;

        _currentSkipDialogPage.OnSkipDialogPage += SkipDialogPage;
        _allWritingPage.OnWriteAllDialogPage += WriteAllPage;
    }

    private void WriteAllPage()
    {
        if (_isContinuationOfDialogueNow && !_isEndingPageDialog)
        {
            _dialogText.text = _currentDialog.DialogPages[_currentPageIndex];
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

    virtual protected void Validate()
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
        DisactivateDialogBar();
        _isContinuationOfDialogueNow = false;

        if (_writingCoroutineReference != null)
            _controllerCoroutine.StopCoroutine(_writingCoroutineReference);

        _eventBus.Invoke(new DialogEndedSignal());
    }

    private void SetDialogInDialogTextCurrentPage()
    {
        if (_writingCoroutineReference != null)
            _controllerCoroutine.StopCoroutine(_writingCoroutineReference);

        _writingCoroutineReference = _controllerCoroutine.StartCoroutine(WritingCoroutine());
    }

    private IEnumerator WritingCoroutine()
    {
        _isEndingPageDialog = false;

        string currentText = string.Empty;
        string fullText = _currentDialog.DialogPages[_currentPageIndex];

        for (int i = 0; i < fullText.Length; i++)
        {
            currentText += fullText[i];

            if (_currentDialog.Sound.AllSounds.Length > 0)
            {
                _dialogAudio.ChangePitch(UnityEngine.Random.Range(0.9f, 0.95f));
                _dialogAudio.PlayOneShot(_currentDialog.Sound.RandomSound);
            }

            _dialogText.text = currentText;
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

    public void StartDialog(BattleDialogData data)
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

    public void Start() => DisactivateDialogBar();

}
