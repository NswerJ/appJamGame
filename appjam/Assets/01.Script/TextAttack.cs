using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAttack : MonoBehaviour
{

    [SerializeField] private GameObject effectPrefab; // 이펙트 프리팹
    private GameObject target; // 타겟
    private bool isMoving = true; // 이동 여부를 나타내는 플래그
    private float moveSpeed = 10f; // 이동 속도

    // 텍스트가 생성될 때 호출됩니다.
    private void Start()
    {
        // 타겟 설정
        SetTarget();
    }

    // 타겟 설정 메서드
    private void SetTarget()
    {
        // 예시로 태그가 "target"인 오브젝트 중에서 첫 번째 타겟을 선택합니다.
        target = GameObject.FindGameObjectWithTag("target");
        if (target == null)
        {
            Debug.LogWarning("No target found!");
        }
    }

    // 업데이트에서 플레이어 위치로 이동
    private void Update()
    {
        if (isMoving && target != null)
        {
            Vector3 targetPosition = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;
                Destroy(gameObject, 2.5f); // 텍스트를 파괴합니다.
            }
        }
        else
        {
            // 타겟이 없는 경우나 이동이 완료된 경우 경고 출력
            Debug.LogWarning("No target available or already reached the target!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어에 닿으면 이 텍스트를 삭제하고 플레이어에게 이펙트를 생성합니다.
            ShowEffect(other.transform.position);
        }
        
    }

    private void ShowEffect(Vector3 position)
    {
        // 이펙트 생성 및 0.5초 후에 삭제
        GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity);
        Destroy(effect, 0.5f);
            Destroy(this.gameObject);
    }

}
