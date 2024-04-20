using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ChoiceStage : MonoBehaviour
{
    public GameObject back;
    public AudioClip click;
    public Sprite[] checkBoxKinds;
    public Image[] checkBoxs;
    public GameObject[] checkSign;
    public GameObject[] textChecker;
    int clearStageIndex =-1;
    private void Start()
    {
        Init();
        UI_EventHandler evt = back.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Destroy(gameObject); };

        //스테이지 이동
        evt = checkBoxs[0].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[0]) return; checkSign[0].SetActive(true); };
        evt = checkBoxs[1].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[1] || clearStageIndex + 1 < 1) return; checkSign[1].SetActive(true); };
        evt = checkBoxs[2].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[2] || clearStageIndex + 1 < 2) return; checkSign[2].SetActive(true); };
        evt = checkBoxs[3].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[3] || clearStageIndex + 1 < 3) return; checkSign[3].SetActive(true); };
        evt = checkBoxs[4].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[4] || clearStageIndex + 1 < 4) return; checkSign[4].SetActive(true); };
        evt = checkBoxs[5].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[5] || clearStageIndex + 1 < 5) return; checkSign[5].SetActive(true); };

        //날짜 텍스트
        evt = textChecker[0].GetComponent<UI_EventHandler>();
        evt.OnEnter += (PointerEventData p) => { if (GameManager.Instance.isClear[0]) return; textChecker[0].GetComponent<CalenderText>().Typing(); };
        evt = textChecker[1].GetComponent<UI_EventHandler>();
        evt.OnEnter += (PointerEventData p) => { if (GameManager.Instance.isClear[1] || clearStageIndex + 1 < 1) return; textChecker[1].GetComponent<CalenderText>().Typing(); };
        evt = textChecker[2].GetComponent<UI_EventHandler>();
        evt.OnEnter += (PointerEventData p) => { if (GameManager.Instance.isClear[2] || clearStageIndex + 1 < 2) return; textChecker[2].GetComponent<CalenderText>().Typing(); };
        evt = textChecker[3].GetComponent<UI_EventHandler>();
        evt.OnEnter += (PointerEventData p) => {if (GameManager.Instance.isClear[3] || clearStageIndex + 1 < 3) return; textChecker[3].GetComponent<CalenderText>().Typing(); };
        evt = textChecker[4].GetComponent<UI_EventHandler>();
        evt.OnEnter += (PointerEventData p) => {if (GameManager.Instance.isClear[4] || clearStageIndex + 1 < 4) return; textChecker[4].GetComponent<CalenderText>().Typing(); };
        evt = textChecker[5].GetComponent<UI_EventHandler>();
        evt.OnEnter += (PointerEventData p) => {if (GameManager.Instance.isClear[5] || clearStageIndex + 1 < 5) return; textChecker[5].GetComponent<CalenderText>().Typing(); };
    }

    void Init()
    {
        for(int i = 0; i < 6; i++)
        {
            if (GameManager.Instance.isClear[i])
            { 
                checkBoxs[i].sprite = checkBoxKinds[0];
                checkSign[i].SetActive(true);
                clearStageIndex = i;
            }
            else
            {
                if(i == clearStageIndex + 1 || i == 0)
                    checkBoxs[i].sprite = checkBoxKinds[0];
                else
                    checkBoxs[i].sprite = checkBoxKinds[1];
                checkSign[i].SetActive(false);
            }
        }
    }
}
