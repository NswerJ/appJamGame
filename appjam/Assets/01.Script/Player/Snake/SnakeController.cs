using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private SnakeSO snakeSO;
    private Rigidbody2D rb;
    private List<Transform> tailParts = new List<Transform>();
    private bool isMoving = true;

    public UnityEvent PreventEvent;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < snakeSO.initialTailCount; i++)
        {
            CreateBodyPart();
        }
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            isMoving = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = true;
        }

        
        if (isMoving)
        {
            rb.velocity = direction * snakeSO.moveSpeed;
            MoveTail();
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5f * Time.deltaTime);
        }

      
    }

    // 部府 捞悼 窃荐
    private void MoveTail()
    {
        for (int i = 0; i < tailParts.Count; i++)
        {
            if (i == 0)
            {
                tailParts[i].position = Vector3.Lerp(tailParts[i].position, transform.position, Time.deltaTime * 10f);
            }
            else
            {
                tailParts[i].position = Vector3.Lerp(tailParts[i].position, tailParts[i - 1].position, Time.deltaTime * 10f);
            }
        }
    }

    // 部府 积己 窃荐
    private void CreateBodyPart()
    {
        Transform newBodyPart = Instantiate(snakeSO.bodyPartPrefab, transform.position, Quaternion.identity);
        tailParts.Add(newBodyPart);
    }

    
}
