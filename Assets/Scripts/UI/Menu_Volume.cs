using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Volume : MonoBehaviour
{
    public Selectable _sfxSlider;

    private void OnEnable()
    {
        _sfxSlider.Select();
    }

    public void SFXSliderChanged(float val)
    {
        AudioService.Instance.SFXVolume = val;
    }


    public void MusicSliderChanged(float val)
    {
        AudioService.Instance.MusicVolume = val;
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }
}
