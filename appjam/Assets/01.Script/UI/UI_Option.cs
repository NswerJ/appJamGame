using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Option : MonoBehaviour
{
    public GameObject back;
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer mixer;
    void Start()
    {
       UI_EventHandler evt = back.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Destroy(gameObject); };
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music",volume);
    }

    public void SetSFXVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music", volume);
    }
}
