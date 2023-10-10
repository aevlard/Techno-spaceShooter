using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager_Antoine : MonoBehaviour
{
    public Slider volumeMusicSlider;
    public Slider volumSoundSlider;
    public AudioClip buttonClickSound;
    public AudioClip backgroundMusic;

    private AudioSource backgroundMusicAudioSource;
    private AudioSource buttonClickAudioSource;

    private void Awake()
    {
        // Cr�ez un AudioSource pour la musique de fond
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource.clip = backgroundMusic;
        backgroundMusicAudioSource.loop = true;

        // Cr�ez un AudioSource pour les sons des boutons
        buttonClickAudioSource = gameObject.AddComponent<AudioSource>();
        buttonClickAudioSource.clip = buttonClickSound;
    }

    void Start()
    {
        // Commencez � jouer la musique de fond
        backgroundMusicAudioSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        // R�glez le volume de la musique de fond
        backgroundMusicAudioSource.volume = volume;
        Debug.Log("music" + volume);
    }

    public void SetEffectVolume(float volume)
    {
        // R�glez le volume de la musique de fond
        buttonClickAudioSource.volume = volume;
        Debug.Log("effect" + volume);
    }

    public void PlayButtonClickSound()
    {
        // Jouez le son du bouton
        buttonClickAudioSource.Play();
    }
}
