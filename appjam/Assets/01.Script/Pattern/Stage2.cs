using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage2 : MonoBehaviour
{
    Pattern3 p3;
    private void Start()
    {
        p3 = GameObject.Find("stage2").GetComponent<Pattern3>();

        StartCoroutine(pattern());
    }
    private IEnumerator pattern()
    {
        yield return new WaitForSeconds(0f);
        while (true)
        {
            p3.play();
            yield return new WaitForSeconds(1f);
            Instantiate(Resources.Load("Circle"));
            Instantiate(Resources.Load("Circle"));
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(1f);
            Instantiate(Resources.Load("Circle"));
            Instantiate(Resources.Load("Circle"));
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(1f);
        }
    }
}
