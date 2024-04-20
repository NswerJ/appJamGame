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
        text1.text = text1Text;
        text2.text = text2Text;
        Destroy(gameObject);
    }
}
