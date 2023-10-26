using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Game Sound Settings")]
    [SerializeField] public AudioClip keyClip;
    [SerializeField] public AudioClip pegClip;
    [SerializeField] public AudioClip backgroundMusic;

    private AudioSource soundEffectSource;
    private AudioSource backgroundMusicSource;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else {
            Destroy(gameObject);
            return;
        }

        soundEffectSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();

        //Hard codes single song into Source, makes it loop then play
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayKeyClip() {
        soundEffectSource.PlayOneShot(keyClip);
    }

    public void PlayPegClip() {
        soundEffectSource.PlayOneShot(pegClip);
    }

    public void PlayBackgroundMusic() {
        if (!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }

    public void PauseBackgroundMusic() {
        backgroundMusicSource.Pause();
    }

    public void StopBackgroundMusic() {
        backgroundMusicSource.Stop();
    }

    public void SetBackgroundMusicVolume(float volume) {
        backgroundMusicSource.volume = volume;
    }
}
