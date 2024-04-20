using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        // 마우스 포인터의 위치를 가져와서 해당 방향으로 회전
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Z 축은 고정
        Vector3 direction = (mousePosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
