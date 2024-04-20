using UnityEngine;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private SnakeSO snakeSO;
    private Rigidbody2D rb;
    private List<Transform> tailParts = new List<Transform>(); // ���� ������Ʈ���� ������ ����Ʈ
    private bool isMoving = true; // �÷��̾�� ������ �̵� ������ ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �ʱ� ���� ����
        for (int i = 0; i < snakeSO.initialTailCount; i++)
        {
            CreateBodyPart();
        }
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // ���콺 ���� ��ư�� ������ �÷��̾�� ������ ���߱�
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            isMoving = false;
        }

        // ���콺 ������ ��ư�� ������ �÷��̾�� ������ �ٽ� �̵��ϱ�
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = true;
        }

        // �÷��̾�� ������ �̵� ���� ������ �̵�
        if (isMoving)
        {
            rb.velocity = direction * snakeSO.moveSpeed;
            MoveTail();
        }
    }

    // ���� �̵� �Լ�
    private void MoveTail()
    {
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
        Transform newBodyPart = Instantiate(snakeSO.bodyPartPrefab, transform.position, Quaternion.identity);
        tailParts.Add(newBodyPart); // ����Ʈ�� �߰�
    }
}
