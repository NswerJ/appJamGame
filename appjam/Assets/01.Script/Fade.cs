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
            // value�� 0 �����̰� isIn�� false�� ��� isIn�� true�� �����մϴ�.
            if (value <= 0 && !isIn)
            {
                isIn = true;
            }
            // value�� 1 �̻��̰� isIn�� true�� ��� isIn�� false�� �����մϴ�.
            else if (value >= 1 && isIn)
            {
                isIn = false;
            }

            // isIn ���� ���� value ���� ���� �Ǵ� ���ҽ�ŵ�ϴ�.
            if (isIn)
            {
                value += 0.075f;
            }
            else
            {
                value -= 0.075f;
            }

            // SpriteRenderer�� ������ ������Ʈ�մϴ�.
            Color col = render.color;
            col.a = value;
            render.color = col;

            // ��� ����մϴ�.
            yield return new WaitForSeconds(0.02f);
        }
    }
}
