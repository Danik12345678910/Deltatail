using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviourService
{
    private Dictionary<string, Audio> _audiosMap = new Dictionary<string, Audio>();
    public Audio MainAudio { get; private set; }

    private void Awake()
    {
        string mainName = "Main";
        Register(mainName);
        MainAudio = GetAudioToName(mainName);
    }

    public void Register(string name)
    {
        if (_audiosMap.ContainsKey(name))
        {
            Debug.LogError($"{typeof(AudioController)}: ");
            return;
        }

        Audio newAudio = new Audio();
        newAudio.Initialize(gameObject);
        _audiosMap.Add(name, newAudio);
    }

    public Audio GetAudioToName(string name)
    {
        if (_audiosMap.ContainsKey(name))
            return _audiosMap[name];
        else
        {
            Debug.LogError($"{typeof(AudioController)}: Уже хранится аудио под таким ключом");
            return null;
        }
    }

    public override Type ServiceType => GetType();

    [Serializable]
    public class Audio
    {
        [field: SerializeField, Range(0f, 1f)]
        public float Volume
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float Pitch
        {
            get;
            private set;
        }

        [field: SerializeField]
        public AudioClip Clip
        {
            get;
            private set;
        }
        [field: SerializeField]
        public bool Loop
        {
            get;
            private set;
        }

        private AudioSource _source;

        public void Initialize(GameObject gameObject, AudioClip clip, bool loop, float volume, float pitch)
        {
            _source = gameObject.AddComponent<AudioSource>();
            ChangeSettings(pitch, volume, loop, clip);
        }

        public void Initialize(GameObject gameObject) => _source = gameObject.AddComponent<AudioSource>();

        public void ChangeVolume(float volume)
        {
            Volume = volume;
            SetVolume();
        }

        public void ChangeClip(AudioClip clip)
        {
            Clip = clip;
            SetClip();
        }
        public void ChangePitch(float pitch)
        {
            Pitch = pitch;
            SetPitch();
        }

        public void ChangeLoop(bool loop)
        {
            Loop = loop;
            SetLoop();
        }

        public void ChangeSettings(float pitch, float volume, bool loop, AudioClip audioClip)
        {
            ChangeVolume(volume);
            ChangePitch(pitch);
            ChangeLoop(loop);
            ChangeClip(audioClip);
        }

        private void SetVolume() => _source.volume = Volume;
        private void SetClip() => _source.clip = Clip;
        private void SetPitch() => _source.pitch = Pitch;
        private void SetLoop() => _source.loop = Loop;

        public void Play() => _source.Play();
        public void PlayOneShot(AudioClip clip) => _source.PlayOneShot(clip);
    }
}

public struct AudioContainer
{
    public AudioController.Audio Audio { get; private set; }
    
    private void Register(string key)
    {
        var audioController = ServiceLocator.Current.GetService<AudioController>();

        if (audioController == null)
            throw new InvalidOperationException("Инициализация вызвана слишком рано");

        audioController.Register(key);
    }

    public void Initialize(string key)
    {
        var audioController = ServiceLocator.Current.GetService<AudioController>();

        Register(key);

        if (audioController == null)
            throw new InvalidOperationException("Инициализация вызвана слишком рано");

        Audio = audioController.GetAudioToName(key);
    }
}