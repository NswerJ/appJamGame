using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Warning : MonoBehaviour
{
    SpriteRenderer render;
    private void Start()
    {
        render = transform.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Fade());
    }
    private IEnumerator Fade()
    {
        float value = 1f;
        bool isIn = false;
        while(true)
        {
            if(value <= 0 && !isIn) { isIn = !isIn; }
            else if(value >= 1 && isIn) { isIn = !isIn; }

            if (isIn) { value += 0.075f; }
            else { value -= 0.075f; }

            Color col = render.material.color;
            col.a = value;
            render.material.color = col;

            yield return new WaitForSeconds(0.02f);
        }
    }
}
