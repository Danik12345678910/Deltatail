using System;
using UnityEngine;
using Zenject;
using static AudioController;

[Serializable]

public class AudioPlayInteraction : InteractionActionEndingHandler
{
    public override event Action OnEndingAction;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _volume;

    [SerializeField] private string _audioName = "InteractAudio";

    private Audio _audio;
    private AudioController _audioController;

    [Inject]
    private void Initialize(AudioController audioController) => _audioController = audioController;

    public override void Start()
    {
        if (_audioController.ContainsAudio(_audioName))
            _audio = _audioController.GetAudio(_audioName);
        else
            _audio = _audioController.RegisterAudio(_audioName);
    }

    public override void Action()
    {
        _audio.OnEndingClip += OnEndingClip;
        _audio.Play();
        
    }

    private void OnEndingClip()
    {
        _audio.OnEndingClip -= OnEndingClip;
        OnEndingAction?.Invoke();
    }
}
