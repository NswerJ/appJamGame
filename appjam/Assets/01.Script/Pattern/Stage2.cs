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
        yield return new WaitForSeconds(6f);
        while (true)
        {
            p3.play();
            yield return new WaitForSeconds(6f);
            Instantiate(Resources.Load("FxxK"));
            yield return new WaitForSeconds(0.6f);
            Instantiate(Resources.Load("FxxK1"));
            yield return new WaitForSeconds(0.8f);
            Instantiate(Resources.Load("FxxK2"));
            yield return new WaitForSeconds(0.8f);
            Instantiate(Resources.Load("FxxK"));
            yield return new WaitForSeconds(7.5f);
        }
    }
}
