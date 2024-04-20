using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform spawnPoint;//스폰이 필요하면 

    [Header("최댓 값")]
    [SerializeField]
    private float SpawnTime = 2.0f; // 일정 시간뒤에 생성
    [SerializeField]
    private float SpanwCount = 1f; // 플레이어 스폰 갯수

    [Header("현재 값")]
    [SerializeField]
    private float SpawnCurrentTime = 0; // 일정 시간뒤에 생성
    [SerializeField]
    private float currentSpanwCount = 0f; // 플레이어 스폰 갯수
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCurrentTime += Time.deltaTime;
        if(SpawnCurrentTime > SpawnTime && SpanwCount > currentSpanwCount)
        {
            currentSpanwCount++;
            Instantiate(player, spawnPoint.position, Quaternion.identity);
            SpawnTime = 0;
        }
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(player, spawnPoint.position, Quaternion.identity);
        }*/
    }
}
