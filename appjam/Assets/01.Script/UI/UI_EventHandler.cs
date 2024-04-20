using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerUpHandler
{
    public Action<PointerEventData> OnClick;
    public Action<PointerEventData> OnEnter;
    public Action<PointerEventData> OnUp;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
            OnClick?.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnEnter != null)
            OnEnter?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnUp != null)
            OnUp?.Invoke(eventData);
    }
}
