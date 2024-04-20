using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAttack : MonoBehaviour
{

    [SerializeField] private GameObject effectPrefab; // ����Ʈ ������
    private GameObject target; // Ÿ��
    private bool isMoving = true; // �̵� ���θ� ��Ÿ���� �÷���
    private float moveSpeed = 10f; // �̵� �ӵ�

    // �ؽ�Ʈ�� ������ �� ȣ��˴ϴ�.
    private void Start()
    {
        // Ÿ�� ����
        SetTarget();
    }

    // Ÿ�� ���� �޼���
    private void SetTarget()
    {
        // ���÷� �±װ� "target"�� ������Ʈ �߿��� ù ��° Ÿ���� �����մϴ�.
        target = GameObject.FindGameObjectWithTag("target");
        if (target == null)
        {
            Debug.LogWarning("No target found!");
        }
    }

    // ������Ʈ���� �÷��̾� ��ġ�� �̵�
    private void Update()
    {
        if (isMoving && target != null)
        {
            Vector3 targetPosition = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;
                Destroy(gameObject, 2.5f); // �ؽ�Ʈ�� �ı��մϴ�.
            }
        }
        else
        {
            // Ÿ���� ���� ��쳪 �̵��� �Ϸ�� ��� ��� ���
            Debug.LogWarning("No target available or already reached the target!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ������ �� �ؽ�Ʈ�� �����ϰ� �÷��̾�� ����Ʈ�� �����մϴ�.
            ShowEffect(other.transform.position);
        }
        
    }

    private void ShowEffect(Vector3 position)
    {
        // ����Ʈ ���� �� 0.5�� �Ŀ� ����
        GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity);
        Destroy(effect, 0.5f);
            Destroy(this.gameObject);
    }

}
