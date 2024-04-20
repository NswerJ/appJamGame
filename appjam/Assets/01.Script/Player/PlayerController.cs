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
            Debug.Log("Ŭ���� �ϸ� �־��ֻ�");
            Destroy(gameObject);
            transform.position = Vector3.zero;
            clearEvent?.Invoke();
        }
        if (collision.CompareTag("Player") || collision.CompareTag("laser") || collision.CompareTag("TEXT"))
        {
            Debug.Log("������ ���� �Ǵ� ��ֹ��� ����");
            dieEvent?.Invoke();
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadNextScene()
    {
        // ���� ���� �ε����� �����ɴϴ�.
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // ���� ���� �ε����� ����մϴ�.
        int nextIndex = currentIndex + 1;

        // ���� ���� �����ϴ��� Ȯ���մϴ�.
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            // ���� ������ �̵��մϴ�.
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available!");
        }
    }
}
