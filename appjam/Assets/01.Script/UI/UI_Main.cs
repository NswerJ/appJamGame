using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public GameObject start;
    public GameObject option;
    public GameObject exit;

    public GameObject changeUI;
    public GameObject optionUI;
    public AudioClip click;
    public Image rose;
    public Sprite redRose;
    void Start()
    {
        UI_EventHandler evt = start.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { StartCoroutine(ChangeScene()); Instantiate(changeUI).GetComponent<Animator>().Play("Before"); GetComponent<AudioSource>().PlayOneShot(click); };
        evt = option.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Instantiate(optionUI); GetComponent<AudioSource>().PlayOneShot(click); };
        evt = exit.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Application.Quit(); };

        if (GameManager.Instance.isClear[5])
            rose.sprite = redRose;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ChoiceStage");
    }
}
