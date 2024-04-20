using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject snake; //지켜줄 지렁이
    [SerializeField]
    private GameObject clearPlayer; //플레이어
    [SerializeField]
    private Transform snakeSpawnPoint; //스폰이 필요하면 
    [SerializeField]
    private Transform ClearPlayerSpawnPoint; //스폰이 필요하면 

    [Header("최댓 값")]
    [SerializeField]
    private float SpawnTime = 2.0f; // 일정 시간뒤에 생성
    [SerializeField]
    private float SnakeCount = 1f; // 플레이어 스폰 갯수
    [SerializeField]
    private float ClearPlayerCount = 1f; // 플레이어 스폰 갯수

    [Header("현재 값")]
    [SerializeField]
    private float SpawnCurrentTime = 0; // 일정 시간뒤에 생성
    [SerializeField]
    private float currentSnakeCount = 0f; // 플레이어 스폰 갯수
    [SerializeField]
    private float currentPlayerCount = 0f; // 플레이어 스폰 갯수
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCurrentTime += Time.deltaTime;
        if (SpawnCurrentTime > SpawnTime && SnakeCount > currentSnakeCount)
        {
            currentSnakeCount++;
            Instantiate(snake, snakeSpawnPoint.position, Quaternion.identity);
            SpawnTime = 0;
        }
       /* if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(snake, snakeSpawnPoint.position, Quaternion.identity);
        }*/
        SpawnCurrentTime += Time.deltaTime;
        if (SpawnCurrentTime > SpawnTime && ClearPlayerCount > currentPlayerCount)
        {
            currentPlayerCount++;
            Instantiate(clearPlayer, ClearPlayerSpawnPoint.position, Quaternion.identity);
            SpawnTime = 0;
        }
    }
}
