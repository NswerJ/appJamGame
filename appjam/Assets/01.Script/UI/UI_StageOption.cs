using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_StageOption : MonoBehaviour
{
    public GameObject continueBtn;
    public GameObject restart;
    public GameObject leave;
    public GameObject changeUI;
    public AudioClip click;
    void Start()
    {
        Time.timeScale = 0;

        UI_EventHandler evt = continueBtn.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Time.timeScale = 0; Destroy(gameObject); };
        evt = restart.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Time.timeScale = 1; StartCoroutine(ChangeScene(0)); };
        evt = leave.GetComponent<UI_EventHandler>();
        evt.OnClick += (PointerEventData p) => { Time.timeScale =1; StartCoroutine(ChangeScene(1)); };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    IEnumerator ChangeScene(int i)
    {
        Instantiate(changeUI).GetComponent<Animator>().Play("Before"); GetComponent<AudioSource>().PlayOneShot(click);
        yield return new WaitForSeconds(1f);
        switch (i)
        {
            case 0:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case 1:
                SceneManager.LoadScene("ChoiceStage");
                break;
        }
    }
}
