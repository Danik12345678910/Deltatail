using UnityEngine;

[CreateAssetMenu(fileName = "AudioDialogData", menuName = "Scriptable Objects/AudioDialogData")]
public class AudioDialogData : ScriptableObject
{
    [field: SerializeField] public AudioClip[] AllSounds { get; private set; }
    public AudioClip RandomSound { get => AllSounds[Random.Range(0, AllSounds.Length)]; }
}
