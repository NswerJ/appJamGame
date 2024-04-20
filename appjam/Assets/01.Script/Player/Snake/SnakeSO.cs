using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("SO/Player/Stat"))]
public class SnakeSO : ScriptableObject
{
    [Header("�÷��̾� ����")]
    [SerializeField] public float moveSpeed = 5f; // �Ӹ� ������� ���ǵ�
    [SerializeField] public float stopDistance = 0.1f; // ���콺 ������ ��ó�� ���� ���ߴ� �Ÿ�
    [SerializeField] public Transform bodyPartPrefab; // ���� ������Ʈ ������
    [SerializeField] public float followInterval = 0.5f; // ������ ������� ����
    [SerializeField] public int initialTailCount = 10; // �ʱ� ���� ����
}
