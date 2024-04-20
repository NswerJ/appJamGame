using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public float rotationSpeed = 5f; // ȸ�� �ӵ�

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        // ���콺 �������� ��ġ�� �����ͼ� �ش� �������� ȸ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Z ���� ����
        Vector3 direction = (mousePosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
