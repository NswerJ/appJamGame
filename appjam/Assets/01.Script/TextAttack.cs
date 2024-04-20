using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAttack : MonoBehaviour
{

    [SerializeField] private GameObject effectPrefab; // ����Ʈ ������

    private GameObject target; // Ÿ��

    // �ؽ�Ʈ�� ������ �� ȣ��˴ϴ�.
    private void Start()
    {
        // Ÿ�� ����
        SetTarget();
        // Ÿ������ �ؽ�Ʈ ������
        StartCoroutine(MoveTextToTarget());
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

    // Ÿ������ �ؽ�Ʈ ������ �ڷ�ƾ
    private IEnumerator MoveTextToTarget()
    {
        if (target != null)
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = target.transform.position;
            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float startTime = Time.time;

            while (transform.position != targetPosition)
            {
                float distanceCovered = (Time.time - startTime) * 5; // �̵� �ӵ��� ������ �� �ֽ��ϴ�.
                float fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }

            // ����Ʈ ���� �� ����
            GameObject effect = Instantiate(effectPrefab, targetPosition, Quaternion.identity);
            Destroy(effect, 0.5f);

            // �ؽ�Ʈ�� �ı��մϴ�.
            Destroy(gameObject);
        }
        else
        {
            // Ÿ���� ���� ��� ��� ���
            Debug.LogWarning("No target available!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ������ �� �ؽ�Ʈ�� �����ϰ� �÷��̾�� ����Ʈ�� �����մϴ�.
            Destroy(gameObject);
            ShowEffect(other.transform.position);
        }
        else if (other.CompareTag("target"))
        {
            // Ÿ�ٿ� ������ Ÿ���� �����ϰ� Ÿ�ٿ��� ����Ʈ�� �����մϴ�.
            Destroy(other.gameObject);
            ShowEffect(other.transform.position);
        }
    }

    private void ShowEffect(Vector3 position)
    {
        // ����Ʈ ���� �� 0.5�� �Ŀ� ����
        GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

}
