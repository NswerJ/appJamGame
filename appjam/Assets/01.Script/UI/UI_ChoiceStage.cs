using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ChoiceStage : MonoBehaviour
{
    public GameObject back;
    public AudioClip click;
    public AudioClip check;
    public Sprite[] checkBoxKinds;
    public Image[] checkBoxs;
    public GameObject[] checkSign;
    public GameObject[] textChecker;
    int clearStageIndex =-1;

    public GameObject changeUI;
    private void Start()
    {
        Init();
        UI_EventHandler evt = back.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { StartCoroutine(ChangeScene(0));  };

        //스테이지 이동
        evt = checkBoxs[0].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[0]) return; checkSign[0].SetActive(true); checkSign[0].GetComponent<Animator>().Play("Check"); StartCoroutine(ChangeScene(1)); };
        evt = checkBoxs[1].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[1] || clearStageIndex + 1 < 1) return; checkSign[1].SetActive(true); checkSign[1].GetComponent<Animator>().Play("Check"); StartCoroutine(ChangeScene(2)); };
        evt = checkBoxs[2].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[2] || clearStageIndex + 1 < 2) return; checkSign[2].SetActive(true); checkSign[2].GetComponent<Animator>().Play("Check"); StartCoroutine(ChangeScene(3)); };
        evt = checkBoxs[3].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[3] || clearStageIndex + 1 < 3) return; checkSign[3].SetActive(true); checkSign[3].GetComponent<Animator>().Play("Check"); StartCoroutine(ChangeScene(4)); };
        evt = checkBoxs[4].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[4] || clearStageIndex + 1 < 4) return; checkSign[4].SetActive(true); checkSign[4].GetComponent<Animator>().Play("Check"); StartCoroutine(ChangeScene(5)); };
        evt = checkBoxs[5].GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { if (GameManager.Instance.isClear[5] || clearStageIndex + 1 < 5) return; checkSign[5].SetActive(true); checkSign[5].GetComponent<Animator>().Play("Check"); StartCoroutine(ChangeScene(6)); };

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

    IEnumerator ChangeScene(int i)
    {
        Instantiate(changeUI).GetComponent<Animator>().Play("Before");
        if (i == 0)
            GetComponent<AudioSource>().PlayOneShot(click);
        else

            GetComponent<AudioSource>().PlayOneShot(check);
        yield return new WaitForSeconds(1);
        switch (i) 
        {
            case 0:
                SceneManager.LoadScene("Main");
                break;
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
            case 4:
                SceneManager.LoadScene("Stage4");
                break;
            case 5:
                SceneManager.LoadScene("Stage5");
                break;
            case 6:
                SceneManager.LoadScene("Stage6");
                break;
        }
    }
}
