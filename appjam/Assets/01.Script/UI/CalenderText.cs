using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CalenderText : MonoBehaviour
{
    public int stageIndex;
    public Text text1;
    public Text text2;
    string text1Text;
    string text2Text;
    bool istyping;
    void Start()
    {
        if (GameManager.Instance.isClear[stageIndex])
            return;
        text1Text = text1.text;
        text2Text = text2.text;
        text1.text = "";
        text2.text = "";
    }

    public void Typing()
    {
        if(!istyping)
            StartCoroutine(TypingEffect());
    }

    IEnumerator TypingEffect()
    {
        istyping = true;
        string s = text1Text;
        for(int i = 0; i < s.Length; i++)
        {
            text1.text += s.Substring(i, 1);
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(1f);
        s = text2Text;
        for (int i = 0; i < s.Length; i++)
        {
            text2.text += s.Substring(i, 1);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }
}
