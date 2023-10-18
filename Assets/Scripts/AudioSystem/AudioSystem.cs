using UnityEngine;

public enum AudioType
{
    Enviroment,
    SFX
}

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private EnviromentAudioManager enviromentAudio;
    [SerializeField] private SFXAudioManager sfxAudio;

    public void PlayEnviromentSound(AudioType audioType, string audioName)
    {

    }
}
