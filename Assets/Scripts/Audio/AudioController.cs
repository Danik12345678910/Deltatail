using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

sealed public class AudioController : MonoBehaviour
{
    private Dictionary<string, Audio> _audiosMap = new Dictionary<string, Audio>();

    public bool ContainsAudio(in string name) => _audiosMap.ContainsKey(name);

    public Audio RegisterAudio(in string name)
    {
        if (_audiosMap.ContainsKey(name))
            throw new InvalidOperationException($"{typeof(AudioController)}: имя уже занято");

        Audio newAudio = new Audio(gameObject);
        _audiosMap.Add(name, newAudio);
        return newAudio;
    }

    public Audio GetAudio(in string name)
    {
        if (_audiosMap.ContainsKey(name))
            return _audiosMap[name];
        else
        {
            Debug.LogError($"{typeof(AudioController)}: Уже хранится аудио под таким ключом");
            return null;
        }
    }

}

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
    private ControllerCoroutine _controllerCoroutine;

    [Inject]
    private void Init(ControllerCoroutine controllerCoroutine) => _controllerCoroutine = controllerCoroutine;

    public event Action OnEndingClip;

    public Audio(GameObject gameObject, AudioClip clip, bool loop, float volume, float pitch)
    {
        _source = gameObject.AddComponent<AudioSource>();
        ChangeSettings(pitch, volume, loop, clip);
    }

    public Audio(GameObject gameObject) => _source = gameObject.AddComponent<AudioSource>();

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

    public void Play()
    {
        _controllerCoroutine.StartCoroutine(EndingHandlerCoroutine(Clip));
        _source.Play();
    }
    private IEnumerator EndingHandlerCoroutine(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        OnEndingClip?.Invoke();
    }
    public void PlayOneShot(AudioClip clip) => _source.PlayOneShot(clip);
}

//public struct AudioContainer
//{
//    public AudioController.Audio Audio { get; private set; }

//    private void Register(string key)
//    {
//        var audioController = ServiceLocator.Current.GetService<AudioController>();
//        audioController.RegisterAudio(key);
//    }

//    public void Initialize(string key)
//    {
//        var audioController = ServiceLocator.Current.GetService<AudioController>();

//        Register(key);

//        if (audioController == null)
//            throw new InvalidOperationException("Инициализация вызвана слишком рано");

//        Audio = audioController.GetAudio(key);
//    }
//}