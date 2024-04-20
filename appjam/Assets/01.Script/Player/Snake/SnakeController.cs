using UnityEngine;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private SnakeSO snakeSO;
    private Rigidbody2D rb;
    private List<Transform> tailParts = new List<Transform>(); // 꼬리 오브젝트들을 관리할 리스트
    private bool isMoving = true; // 플레이어와 꼬리가 이동 중인지 여부

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 초기 꼬리 생성
        for (int i = 0; i < snakeSO.initialTailCount; i++)
        {
            CreateBodyPart();
        }
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // 마우스 왼쪽 버튼을 누르면 플레이어와 꼬리를 멈추기
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            isMoving = false;
        }

        // 마우스 오른쪽 버튼을 누르면 플레이어와 꼬리를 다시 이동하기
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = true;
        }

        // 플레이어와 꼬리가 이동 중일 때에만 이동
        if (isMoving)
        {
            rb.velocity = direction * snakeSO.moveSpeed;
            MoveTail();
        }
    }

    // 꼬리 이동 함수
    private void MoveTail()
    {
        // 각 꼬리 오브젝트를 플레이어 머리를 따라가게 함
        for (int i = 0; i < tailParts.Count; i++)
        {
            // 꼬리 오브젝트가 플레이어 머리를 따라가도록 함
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

    // 꼬리 생성 함수
    private void CreateBodyPart()
    {
        Transform newBodyPart = Instantiate(snakeSO.bodyPartPrefab, transform.position, Quaternion.identity);
        tailParts.Add(newBodyPart); // 리스트에 추가
    }
}
