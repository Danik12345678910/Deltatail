using System;
using UnityEngine;
using static AudioController;

[Serializable]

public class AudioPlayInteraction : InteractionActionEndingHandler
{
    public override event Action OnEndingAction;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _volume;

    [SerializeField] private string _audioName = "InteractAudio";

    private Audio _audio;
     
    public override void Initialize()
    {
        AudioController audioController = ServiceLocator.Current.GetService<AudioController>();

        if (audioController.ContainsAudio(_audioName))
            _audio = audioController.GetAudio(_audioName);
        else
            _audio = audioController.RegisterAudio(_audioName);
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
