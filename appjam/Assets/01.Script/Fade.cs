using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
public class Fade : MonoBehaviour
{
    SpriteRenderer render;
    private void Start()
    {
        render = GetComponent<SpriteRenderer>();

        StartCoroutine(fade());
    }
    private IEnumerator fade()
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
