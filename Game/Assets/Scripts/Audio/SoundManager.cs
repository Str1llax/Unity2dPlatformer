using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource _masterAudio;
    private AudioSource _musicAudio;
    private AudioSource _sfxAudio;
    
    private void Awake()
    {
        _masterAudio = GetComponent<AudioSource>();
        _musicAudio = transform.GetChild(0).GetComponent<AudioSource>();
        _sfxAudio = transform.GetChild(1).GetComponent<AudioSource>();
        
        SetVolume("MasterVolume", _masterAudio);
        SetVolume("MusicVolume", _musicAudio);
        SetVolume("SfxVolume", _sfxAudio);
        
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if( Instance is not null && Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private static void ChangeVolume(float change, string key, AudioSource source)
    {
        var volume = PlayerPrefs.GetFloat(key, 1f);
        volume += change;
        if (volume > 1)
        {
            volume = 0;
        }
        else if( volume < 0)
        {
            volume = 1;
        }
        source.volume = volume;
        PlayerPrefs.SetFloat(key, volume);
    }

    private void SetVolume(string key, AudioSource source)
    {
        source.volume = PlayerPrefs.GetFloat(key);
    }

    public void ChangeMasterVolume(float volume)
    {
        ChangeVolume(volume, "MasterVolume", _masterAudio);
    }

    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(volume, "MusicVolume", _musicAudio);
    }

    public void ChangeSfxVolume(float volume)
    {
        ChangeVolume(volume, "SfxVolume", _sfxAudio);
    }
}
