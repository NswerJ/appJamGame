using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Pattern3 : MonoBehaviour
{
    GameObject target;

    float width;
    float height;

    private void Start()
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Camera.main.aspect;

        target = GameObject.Find("target");

        StartCoroutine(pattern());
    }
    private IEnumerator pattern()
    {
        float xpos;
        float ypos;

        GameObject p1 = (GameObject)Instantiate(Resources.Load("Circle"));

        yield return new WaitForSeconds(0.05f);

        Vector2 vec = p1.transform.position;

        yield return new WaitForSeconds(3f);

        GameObject p2 = (GameObject)Instantiate(Resources.Load("Square"));

        xpos = Mathf.Clamp(vec.x, width / 2 + 1f, width / 2 - 1f);
        ypos = Mathf.Clamp(vec.y, height / 2 + 1f, height / 2 - 1f);

        p2.transform.position = new Vector3(-xpos + target.transform.position.x, -ypos + target.transform.position.y, 0);
    }
}