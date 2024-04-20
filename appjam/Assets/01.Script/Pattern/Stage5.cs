using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : MonoBehaviour
{
    Pattern3 p3;
    Pattern4 p4;
    private void Start()
    {
        p3 = GameObject.Find("stage5").GetComponent<Pattern3>();
        p4 = GameObject.Find("stage5").GetComponent<Pattern4>();

        StartCoroutine(pattern());
    }
    private IEnumerator pattern()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(5f);
            p3.play();
            yield return new WaitForSeconds(4f);
            p4.play();
            yield return new WaitForSeconds(3f);
        }
    }
}
