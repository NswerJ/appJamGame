using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform spawnPoint;//������ �ʿ��ϸ� 

    [Header("�ִ� ��")]
    [SerializeField]
    private float SpawnTime = 2.0f; // ���� �ð��ڿ� ����
    [SerializeField]
    private float SpanwCount = 1f; // �÷��̾� ���� ����

    [Header("���� ��")]
    [SerializeField]
    private float SpawnCurrentTime = 0; // ���� �ð��ڿ� ����
    [SerializeField]
    private float currentSpanwCount = 0f; // �÷��̾� ���� ����
    
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
