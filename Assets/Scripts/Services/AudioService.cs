using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    public static AudioService Instance;
    private AudioSource _audioSource;

    public float MusicVolume = 1;
    public float SFXVolume = 3;

    private void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            _audioSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

    }


    public void PlayAudio(string audioID, bool randomPitch = false)
    {
        AudioClip clip = Resources.Load("sfx\\" + audioID) as AudioClip;
        if (null == clip) Debug.LogError("Audio Clip Not Found");

        if (!randomPitch)
        {     
            _audioSource.PlayOneShot(clip, SFXVolume);
        }
        else
        {
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.loop = false;
            audio.pitch = Random.Range(.9f, 1.2f);
            audio.volume = SFXVolume;
            audio.clip = clip;
            audio.Play();
            Destroy(audio, clip.length+1);
        }
    }


}
