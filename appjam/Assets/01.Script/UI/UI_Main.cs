using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Main : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject exit;

    public GameObject stageUI;
    public GameObject optionUI;
    public AudioClip click;
    void Start()
    {
        UI_EventHandler evt = start.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Instantiate(stageUI); GetComponent<AudioSource>().PlayOneShot(click); };
        evt = option.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Instantiate(optionUI); GetComponent<AudioSource>().PlayOneShot(click); };
        evt = exit.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Application.Quit(); };
    }
}
