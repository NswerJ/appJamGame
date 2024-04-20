using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage1 : MonoBehaviour
{
    Pattern3 p3;
    private void Start()
    {
        p3 = GameObject.Find("stage1").GetComponent<Pattern3>();

        Debug.Log(p3);
        StartCoroutine(pattern());
    }
    private IEnumerator pattern()
    {
        if(p3 == null)
        {
            Debug.Log(p3);
        }
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            p3.play();
            yield return new WaitForSeconds(8f);
        }
    }
}
