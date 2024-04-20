using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform clearPlace;
    public Vector3 clearRange;
    public float playerSpeed;

    public UnityEvent dieEvent;
    public UnityEvent clearEvent;

    private void Start()
    {
        clearPlace = GameObject.Find("Clear").transform;
        clearPlace.position = new Vector3(transform.position.x + clearRange.x, transform.position.y, transform.position.z);
    }

    public void playerDie()
    {
        Destroy(gameObject);
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
        if (collision.CompareTag("SNAKETAIL"))
        {
            Debug.Log("꼬리에 맞음");
            dieEvent?.Invoke();
        }
        if (collision.CompareTag("SNAKEHEAD"))
        {
            Debug.Log("머리에 맞음");
            dieEvent?.Invoke();
        }
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("장애물에 맞음");
            dieEvent?.Invoke();
        }
    }
}
