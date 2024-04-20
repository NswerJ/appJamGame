using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    private Rigidbody2D rb;
    private List<Transform> tailParts = new List<Transform>(); // ���� ������Ʈ���� ������ ����Ʈ

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �ʱ� ���� ����
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


        // �� ���� ������Ʈ�� �÷��̾� �Ӹ��� ���󰡰� ��
        for (int i = 0; i < tailParts.Count; i++)
        {
            // ���� ������Ʈ�� �÷��̾� �Ӹ��� ���󰡵��� ��
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

    // ���� ���� �Լ�
    private void CreateBodyPart()
    {
        Transform newBodyPart = Instantiate(playerSO.bodyPartPrefab, transform.position, Quaternion.identity);
        tailParts.Add(newBodyPart); // ����Ʈ�� �߰�
    }
}
