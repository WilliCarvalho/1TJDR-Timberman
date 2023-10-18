using UnityEngine;

public enum EnviromentAudioType
{
    Menu,
    Gameplay,
    GameOver
}

[RequireComponent(typeof(AudioSource))]
public class EnviromentAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] enviromentAudios;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChooseSoundType(EnviromentAudioType audioType)
    {
        switch (audioType)
        {
            case EnviromentAudioType.Menu:
                PlaySound(enviromentAudios[0]);
                break;
            case EnviromentAudioType.Gameplay:
                PlaySound(enviromentAudios[1]);
                break;
            case EnviromentAudioType.GameOver:
                PlaySound(enviromentAudios[2]);
                break;
            default:
                break;
        }
    }

    private void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
