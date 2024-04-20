using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage1 : MonoBehaviour
{
    Pattern3 p3;
    private void Start()
    {
        p3 = GameObject.Find("stage1").GetComponent<Pattern3>();

        StartCoroutine(pattern());
    }
    private IEnumerator pattern()
    {
        yield return new WaitForSeconds(2f);
        while(true)
        {
            p3.play();
            yield return new WaitForSeconds(1f);
        }
    }
}
