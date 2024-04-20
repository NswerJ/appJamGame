using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SocialPlatforms;

public class CountDown : MonoBehaviour
{
    Text text;
    private void Start()
    {
        text = transform.GetComponent<Text>();

        StartCoroutine(countDown());
    }
    private IEnumerator countDown()
    {
        text.text = "3";
        yield return new WaitForSeconds(1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        text.text = "√‚πﬂ";
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
