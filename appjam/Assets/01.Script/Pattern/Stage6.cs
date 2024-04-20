using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6 : MonoBehaviour
{
    Pattern3 p3;
    Pattern4 p4;
    private void Start()
    {
        p3 = GameObject.Find("stage6").GetComponent<Pattern3>();
        p4 = GameObject.Find("stage6").GetComponent<Pattern4>();

        StartCoroutine(pattern());
    }
    private IEnumerator pattern()
    {
        yield return new WaitForSeconds(4f);
        while (true)
        {
            p3.play();
            yield return new WaitForSeconds(4f);
            p4.play();
            yield return new WaitForSeconds(6f); 
            Instantiate(Resources.Load("FxxK"));
            yield return new WaitForSeconds(3f);
            Instantiate(Resources.Load("FxxK2"));
            yield return new WaitForSeconds(3f);
            Instantiate(Resources.Load("FxxK3"));
            yield return new WaitForSeconds(5f);
        }
    }
}
