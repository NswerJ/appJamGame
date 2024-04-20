using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pattern4 : MonoBehaviour
{
    Vector3 target;

    float delay = 0.7f;

    private void Start()
    {
    }
    public void play()
    {
        StartCoroutine(pattern());
    }
    public IEnumerator pattern()
    {
        target = GameObject.Find("target").transform.position;

        GameObject go;

        go = (GameObject)Instantiate(Resources.Load("Square"));
        go.transform.position = new Vector3(target.x, target.y + 4.5f);

        yield return new WaitForSeconds(delay);

        go = (GameObject)Instantiate(Resources.Load("Square"));
        go.transform.position = new Vector3(target.x - 4f, target.y - 3f);

        yield return new WaitForSeconds(delay);

        go = (GameObject)Instantiate(Resources.Load("Square"));
        go.transform.position = new Vector3(target.x - 4f, target.y + 3f);

        yield return new WaitForSeconds(delay);

        go = (GameObject)Instantiate(Resources.Load("Square"));
        go.transform.position = new Vector3(target.x, target.y - 4.5f);

        yield return new WaitForSeconds(delay);
    }
}
