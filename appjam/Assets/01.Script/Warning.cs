using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    SpriteRenderer render;
    public Transform target; // target�� ��ġ�� ������ ����
    Transform enemy; // enemy�� ��ġ�� ������ ����

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();

        // target�� enemy�� ��ġ�� ã���ϴ�.
        enemy = transform.parent;

        target = GameObject.Find("target").transform;
        // Warning ������Ʈ�� enemy�� �ڽ����� �����մϴ�.
        transform.SetParent(enemy);

        // �߰� ���� ���
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
