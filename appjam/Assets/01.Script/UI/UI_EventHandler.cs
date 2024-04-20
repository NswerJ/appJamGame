using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler
{
    public Action<PointerEventData> OnClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
            OnClick?.Invoke(eventData);
    }
}
