using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Help : MonoBehaviour
{
    public GameObject back;
    void Start()
    {
        UI_EventHandler evt = back.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Destroy(gameObject); };
    }
}
