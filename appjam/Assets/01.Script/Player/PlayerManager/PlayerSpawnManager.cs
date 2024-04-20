using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject snake; //������ ������
    [SerializeField]
    private GameObject clearPlayer; //�÷��̾�
    [SerializeField]
    private Transform snakeSpawnPoint; //������ �ʿ��ϸ� 
    [SerializeField]
    private Transform ClearPlayerSpawnPoint; //������ �ʿ��ϸ� 

    [Header("�ִ� ��")]
    [SerializeField]
    private float SpawnTime = 2.0f; // ���� �ð��ڿ� ����
    [SerializeField]
    private float SnakeCount = 1f; // �÷��̾� ���� ����
    [SerializeField]
    private float ClearPlayerCount = 1f; // �÷��̾� ���� ����

    [Header("���� ��")]
    [SerializeField]
    private float SpawnCurrentTime = 0; // ���� �ð��ڿ� ����
    [SerializeField]
    private float currentSnakeCount = 0f; // �÷��̾� ���� ����
    [SerializeField]
    private float currentPlayerCount = 0f; // �÷��̾� ���� ����
    
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
