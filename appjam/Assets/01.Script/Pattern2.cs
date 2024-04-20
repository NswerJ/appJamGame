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
            "�����Ҽ��־�?",
            "�������⿡�¾ƴѰŰ�����",
            "���̱׷�����?",
            "���߸𸣰ھ�",
            "�ƴѰŰ����̰�",
            "�ʰ��Ҽ��ִ����߸𸣰ھ�"
        },
        new string[] {
            "�����Ҽ��־�?",
            "�������⿡�¾ƴѰŰ�����",
            "���̱׷�����?",
            "���߸𸣰ھ�",
            "�ƴѰŰ����̰�",
            "�ʰ��Ҽ��ִ����߸𸣰ھ�"
        },
        new string[] {
            "�������ٺ��ξ�",
            "��̾���",
            "���پƴ°��־�?",
            "����������?",
            "�׷��Ը����̷������غ�",
            "���̱׷�����?",
            "�������⿡�¾ƴѰŰ�����",
        },
        new string[] {
            "�������ٺ��ξ�",
            "��̾���",
            "���پƴ°��־�?",
            "����������?",
            "�׷��Ը����̷������غ�",
            "���̱׷�����?",
            "�������⿡�¾ƴѰŰ�����",
        },
        new string[] {
            "������",
            "�׳ɲ���",
            "���ʿ����",
            "��¥���ϴ±���",
            "����������������ϴµ�?",
            "�׸�������",
            "����������������"
        },
        new string[] {
            "�����Ҽ��־�?",
            "�������⿡�¾ƴѰŰ�����",
            "���̱׷�����?",
            "���߸𸣰ھ�",
            "�ƴѰŰ����̰�",
            "�ʰ��Ҽ��ִ����߸𸣰ھ�"
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


