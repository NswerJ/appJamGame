using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("SO/Player/Stat"))]
public class SnakeSO : ScriptableObject
{
    [Header("플레이어 스탯")]
    [SerializeField] public float moveSpeed = 5f; // 머리 따라오는 스피드
    [SerializeField] public float stopDistance = 0.1f; // 마우스 포인터 근처로 오면 멈추는 거리
    [SerializeField] public Transform bodyPartPrefab; // 꼬리 오브젝트 프리팹
    [SerializeField] public float followInterval = 0.5f; // 꼬리가 따라오는 간격
    [SerializeField] public int initialTailCount = 10; // 초기 꼬리 개수
}
