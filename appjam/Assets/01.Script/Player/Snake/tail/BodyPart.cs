using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도
    public UnityEvent PreventEvent;
    private bool isMoving = true;
    private bool hasCollided = false; // 충돌 여부를 나타내는 변수
    [SerializeField] private GameObject effectPrefab; // 이펙트 프리팹

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
        if (isMoving && !hasCollided) // 충돌하지 않은 상태에서만 회전하도록 조건 추가
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
        if (collision.CompareTag("laser") && !hasCollided) // 충돌하지 않은 상태에서만 이펙트 생성하도록 조건 추가
        {
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            hasCollided = true; // 충돌 상태로 변경

            // 0.5초 후에 다시 충돌 여부를 false로 변경하는 코루틴 시작
            StartCoroutine(ResetCollision());
        }
    }

    // 충돌 상태를 재설정하는 코루틴
    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(0.5f);
        hasCollided = false; // 충돌 상태를 false로 재설정
    }
}
