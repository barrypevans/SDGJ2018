using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    public static AudioService Instance;
    private AudioSource _audioSource;
    private void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(this);
        }

    }


    public void PlayAudio (string audioID)
    {
        AudioClip clip = Resources.Load("sfx\\" + audioID) as AudioClip;
        if (null == clip) Debug.LogError("Audio Clip Not Found");
        _audioSource.PlayOneShot(clip,3);
    }


}
