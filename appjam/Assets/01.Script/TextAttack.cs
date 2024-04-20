using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAttack : MonoBehaviour
{

    [SerializeField] private GameObject effectPrefab; // 이펙트 프리팹

    private GameObject target; // 타겟

    // 텍스트가 생성될 때 호출됩니다.
    private void Start()
    {
        // 타겟 설정
        SetTarget();
        // 타겟으로 텍스트 보내기
        StartCoroutine(MoveTextToTarget());
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

    // 타겟으로 텍스트 보내는 코루틴
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
                float distanceCovered = (Time.time - startTime) * 5; // 이동 속도를 조정할 수 있습니다.
                float fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }

            // 이펙트 생성 및 삭제
            GameObject effect = Instantiate(effectPrefab, targetPosition, Quaternion.identity);
            Destroy(effect, 0.5f);

            // 텍스트를 파괴합니다.
            Destroy(gameObject);
        }
        else
        {
            // 타겟이 없는 경우 경고 출력
            Debug.LogWarning("No target available!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어에 닿으면 이 텍스트를 삭제하고 플레이어에게 이펙트를 생성합니다.
            Destroy(gameObject);
            ShowEffect(other.transform.position);
        }
        else if (other.CompareTag("target"))
        {
            // 타겟에 닿으면 타겟을 삭제하고 타겟에게 이펙트를 생성합니다.
            Destroy(other.gameObject);
            ShowEffect(other.transform.position);
        }
    }

    private void ShowEffect(Vector3 position)
    {
        // 이펙트 생성 및 0.5초 후에 삭제
        GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity);
        Destroy(effect, 0.5f);
    }

}
