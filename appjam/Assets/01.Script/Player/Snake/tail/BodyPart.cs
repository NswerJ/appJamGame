using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    public float rotationSpeed = 5f; // ȸ�� �ӵ�
    public UnityEvent PreventEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            PreventEvent?.Invoke();
            Debug.Log("���ع� ����");
        }
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = (mousePosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
