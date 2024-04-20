using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : MonoBehaviour
{
    Pattern3 p3;
    private void Start()
    {
        p3 = GameObject.Find("stage4").GetComponent<Pattern3>();

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
            yield return new WaitForSeconds(7f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("Circle"));
            yield return new WaitForSeconds(7f);
            p3.play();
            yield return new WaitForSeconds(5f);
            p3.play();
            yield return new WaitForSeconds(4f);
        }
    }
}
