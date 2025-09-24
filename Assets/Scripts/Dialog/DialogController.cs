using System;
using System.Collections;
using TMPro;
using UnityEngine;

abstract public class DialogController : MonoBehaviourService
{
    [SerializeField] private GameObject _dialogBar;
    [SerializeField] private TMP_Text _dialogText;
    private AudioContainer _dialogAudio;

    private DialogData _currentDialog;
    private bool _isContinuationOfDialogueNow;
    private bool _isEndingPageDialog;
    private int _currentPageIndex;

    public override Type ServiceType => GetType();

    private ISkipDialogPage _currentSkipDialogPage;

    private EventBus _eventBus;

    protected Coroutine WritingCoroutineReference { private set; get; }

    protected event Action OnStartedDialog;


    private void Awake()
    {
        DisactivateDialogBar();
    }

    private void Start()
    {
        _eventBus = ServiceLocator.Current.GetService<EventBus>();
    }

    public void Initialize(ISkipDialogPage skipDialog, string audioKey)
    {
        _dialogAudio.Initialize(audioKey);
        _currentSkipDialogPage = skipDialog;

        _currentSkipDialogPage.OnSkipDialogPage += SkipDialogPage;
    }

    private void WriteAllPage()
    {
        if (_isContinuationOfDialogueNow && !_isEndingPageDialog)
        {
            _dialogText.text = _currentDialog.DialogPages[_currentPageIndex];
            _isEndingPageDialog = true;
            StopCoroutine(WritingCoroutineReference);
            WritingCoroutineReference = null;
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

    public void StartDialog(DialogData dialog)
    {
        if (!_isContinuationOfDialogueNow)
        {
            _currentPageIndex = 0;
            _currentDialog = dialog;

            Validate();

            OnStartedDialog?.Invoke();

            _isContinuationOfDialogueNow = true;
            _eventBus.Invoke(new DialogStartedSignal());

            ActivateDialogBar();
            SetDialogInDialogTextCurrentPage();
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
        DisactivateDialogBar();
        _isContinuationOfDialogueNow = false;

        if (WritingCoroutineReference != null)
            StopCoroutine(WritingCoroutineReference);

        _eventBus.Invoke(new DialogEndedSignal());
    }

    private void SetDialogInDialogTextCurrentPage()
    {
        if (WritingCoroutineReference != null)
            StopCoroutine(WritingCoroutineReference);

        WritingCoroutineReference = StartCoroutine(WritingCoroutine());
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
                _dialogAudio.Audio.ChangePitch(UnityEngine.Random.Range(0.9f, 0.95f));
                _dialogAudio.Audio.PlayOneShot(_currentDialog.Sound.RandomSound);
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
    }
}
