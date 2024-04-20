using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Main : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject exit;

    public GameObject optionUI;
    void Start()
    {
        UI_EventHandler evt = start.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => {  };
        evt = option.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Instantiate(optionUI); };
        evt = exit.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Application.Quit(); };
    }
}
