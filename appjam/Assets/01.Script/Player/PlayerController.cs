using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform clearPlace;
    public Vector3 clearRange;
    public float playerSpeed;
    public GameObject dieEffect;

    public UnityEvent dieEvent;
    public UnityEvent clearEvent;

    private void Start()
    {
        clearPlace = GameObject.Find("Clear").transform;
        clearPlace.position = new Vector3(transform.position.x + clearRange.x, transform.position.y, transform.position.z);
    }

    public void playerDie()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame

    void Update()
    {
        Vector3 direction = (clearPlace.position - transform.position).normalized;

        Vector3 movement = direction * playerSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CLEAR"))
        {
            Debug.Log("클리어 하면 넣어주삼");
            Destroy(gameObject);
            transform.position = Vector3.zero;
            clearEvent?.Invoke();
        }
        if (collision.CompareTag("Player") || collision.CompareTag("laser") || collision.CompareTag("TEXT"))
        {
            Debug.Log("꼬리에 맞음 또는 장애물에 맞음");
            dieEvent?.Invoke();
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadNextScene()
    {
        // 현재 씬의 인덱스를 가져옵니다.
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 씬의 인덱스를 계산합니다.
        int nextIndex = currentIndex + 1;

        // 다음 씬이 존재하는지 확인합니다.
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            // 다음 씬으로 이동합니다.
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available!");
        }
    }
}
