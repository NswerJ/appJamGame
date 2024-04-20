using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    public float rotationSpeed = 5f; // ȸ�� �ӵ�
    public UnityEvent PreventEvent;
    private bool isMoving = true;
    private bool hasCollided = false; // �浹 ���θ� ��Ÿ���� ����
    [SerializeField] private GameObject effectPrefab; // ����Ʈ ������

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = true;
        }
        if (isMoving && !hasCollided) // �浹���� ���� ���¿����� ȸ���ϵ��� ���� �߰�
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector3 direction = (mousePosition - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("laser") && !hasCollided) // �浹���� ���� ���¿����� ����Ʈ �����ϵ��� ���� �߰�
        {
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            hasCollided = true; // �浹 ���·� ����

            // 0.5�� �Ŀ� �ٽ� �浹 ���θ� false�� �����ϴ� �ڷ�ƾ ����
            StartCoroutine(ResetCollision());
        }
    }

    // �浹 ���¸� �缳���ϴ� �ڷ�ƾ
    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(0.5f);
        hasCollided = false; // �浹 ���¸� false�� �缳��
    }
}
