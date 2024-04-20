using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public bool[] isClear = new bool[6];
}
