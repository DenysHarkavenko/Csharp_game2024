using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioClip runningClip;
    private AudioSource audioSource; 
    public AudioSource runningAudioSource;

    private float musicVolume = 1f; 
    private float runningVolume = 10f;
    private float masterVolume = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        runningAudioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();

        runningAudioSource.clip = runningClip;
        runningAudioSource.loop = true;
    }
    
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume / 10f;
        UpdateVolumes();
    }

    public void SetRunningVolume(float volume)
    {
        runningVolume = volume / 10f;
        UpdateVolumes();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume / 10f;
        UpdateVolumes();
    }

    private void UpdateVolumes()
    {
        audioSource.volume = musicVolume * masterVolume;
        runningAudioSource.volume = runningVolume * masterVolume;
    }

    public void StartRunningSound()
    {
        if (!runningAudioSource.isPlaying)
        {
            runningAudioSource.Play();
        }
    }

    public void StopRunningSound()
    {
        if (runningAudioSource.isPlaying)
        {
            runningAudioSource.Stop();
        }
    }
}