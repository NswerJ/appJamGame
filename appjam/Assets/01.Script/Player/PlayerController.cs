using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    private Rigidbody2D rb;
    private List<Transform> tailParts = new List<Transform>(); // 꼬리 오브젝트들을 관리할 리스트

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 초기 꼬리 생성
        for (int i = 0; i < playerSO.initialTailCount; i++)
        {
            CreateBodyPart();
        }

    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        rb.velocity = direction * playerSO.moveSpeed;

        if (Vector2.Distance(transform.position, mousePosition) <= playerSO.stopDistance)
        {
            rb.velocity = Vector2.zero;
        }


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
        Transform newBodyPart = Instantiate(playerSO.bodyPartPrefab, transform.position, Quaternion.identity);
        tailParts.Add(newBodyPart); // 리스트에 추가
    }
}
