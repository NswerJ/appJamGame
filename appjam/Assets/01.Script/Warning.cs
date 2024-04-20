using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    SpriteRenderer render;
    public Transform target; // target의 위치를 저장할 변수
    Transform enemy; // enemy의 위치를 저장할 변수

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();

        // target과 enemy의 위치를 찾습니다.
        enemy = transform.parent;

        target = GameObject.Find("target").transform;
        // Warning 오브젝트를 enemy의 자식으로 설정합니다.
        transform.SetParent(enemy);

        // 중간 지점 계산
        Vector3 middlePoint = (enemy.position + target.position) / 2f;
        transform.position = middlePoint;

        StartCoroutine(Fade());
        Destroy(gameObject, 2f);
    }

    private IEnumerator Fade()
    {
        float value = 1f;
        bool isIn = false;
        while (true)
        {
            // value가 0 이하이고 isIn이 false인 경우 isIn을 true로 변경합니다.
            if (value <= 0 && !isIn)
            {
                isIn = true;
            }
            // value가 1 이상이고 isIn이 true인 경우 isIn을 false로 변경합니다.
            else if (value >= 1 && isIn)
            {
                isIn = false;
            }

            // isIn 값에 따라 value 값을 증가 또는 감소시킵니다.
            if (isIn)
            {
                value += 0.075f;
            }
            else
            {
                value -= 0.075f;
            }

            // SpriteRenderer의 색상을 업데이트합니다.
            Color col = render.color;
            col.a = value;
            render.color = col;

            // 잠시 대기합니다.
            yield return new WaitForSeconds(0.02f);
        }
    }
}
