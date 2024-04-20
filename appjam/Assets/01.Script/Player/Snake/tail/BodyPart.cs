using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도
    public UnityEvent PreventEvent;
    private bool isMoving = true;

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
        if (isMoving)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector3 direction = (mousePosition - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
        
    }
}
