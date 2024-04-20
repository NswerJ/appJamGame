using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

enum StageSentences
{
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
    Stage6,
}

public class Pattern2 : MonoBehaviour
{
    [SerializeField] private TextMeshPro textPrefab;
    private List<string[]> stageSentences = new List<string[]> {
        new string[] {
            "정말할수있어?",
            "내가보기에는아닌거같은데",
            "굳이그래야해?",
            "난잘모르겠어",
            "아닌거같아이건",
            "너가할수있는지잘모르겠어"
        },
        new string[] {
            "정말할수있어?",
            "내가보기에는아닌거같은데",
            "굳이그래야해?",
            "난잘모르겠어",
            "아닌거같아이건",
            "너가할수있는지잘모르겠어"
        },
        new string[] {
            "생각보다별로야",
            "재미없어",
            "할줄아는게있어?",
            "뭐가문제야?",
            "그렇게말고이렇게좀해봐",
            "굳이그래야해?",
            "내가보기에는아닌거같은데",
        },
        new string[] {
            "생각보다별로야",
            "재미없어",
            "할줄아는게있어?",
            "뭐가문제야?",
            "그렇게말고이렇게좀해봐",
            "굳이그래야해?",
            "내가보기에는아닌거같은데",
        },
        new string[] {
            "저리가",
            "그냥꺼져",
            "너필요없어",
            "진짜못하는구나",
            "내가어디까지해줬야하는데?",
            "그만해이제",
            "내눈에띄지마이제"
        },
        new string[] {
            "정말할수있어?",
            "내가보기에는아닌거같은데",
            "굳이그래야해?",
            "난잘모르겠어",
            "아닌거같아이건",
            "너가할수있는지잘모르겠어"
        },
    };

    private string[] currentSentences;

    private void Start()
    {
        currentSentences = GetStageSentences();
        StartCoroutine(ShowTextCharacters());
    }

    private string[] GetStageSentences()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        switch (currentSceneName)
        {
            case "Stage1":
                return stageSentences[(int)StageSentences.Stage1];
            case "Stage2":
                return stageSentences[(int)StageSentences.Stage2];
            case "Stage3":
                return stageSentences[(int)StageSentences.Stage3];
            case "Stage4":
                return stageSentences[(int)StageSentences.Stage4];
            case "Stage5":
                return stageSentences[(int)StageSentences.Stage5];
            case "Stage6":
                return stageSentences[(int)StageSentences.Stage6];
            default:
                Debug.LogWarning("Unknown scene: " + currentSceneName);
                return null;
        }
    }

    private IEnumerator ShowTextCharacters()
    {
        yield return new WaitForSeconds(2f);
        string randomSentence = currentSentences[Random.Range(0, currentSentences.Length)];

        foreach (char letter in randomSentence)
        {
            TextMeshPro textInstance = Instantiate(textPrefab, transform.position, Quaternion.identity);
            textInstance.text = letter.ToString();
            yield return new WaitForSeconds(0.15f);
        }
    }
}


