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
        yield return new WaitForSeconds(6f);
        while (true)
        {
            Instantiate(Resources.Load("FxxK"));
            yield return new WaitForSeconds(4f);
            Instantiate(Resources.Load("FxxK"));
            yield return new WaitForSeconds(0.7f);
            Instantiate(Resources.Load("FxxK1"));
            yield return new WaitForSeconds(7f);
            Instantiate(Resources.Load("FxxK3"));
            yield return new WaitForSeconds(7f);
            p3.play();
            yield return new WaitForSeconds(5f);
            p3.play();
            yield return new WaitForSeconds(4f);
        }
    }
}
