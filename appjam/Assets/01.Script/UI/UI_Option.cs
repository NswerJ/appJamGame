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
    public AudioClip click;
    public Sprite[] btnKind;
    public GameObject[] button;
    public AudioSource[] audioSource;
    void Start()
    {
       UI_EventHandler evt = back.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Destroy(gameObject); };
       evt = button[0].GetComponent<UI_EventHandler>();
        if (PlayerPrefs.HasKey("musicVolume"))
         LoadVolume();
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music",Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        audioSource[1].PlayOneShot(click);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        audioSource[0].PlayOneShot(click);
    }

    void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
