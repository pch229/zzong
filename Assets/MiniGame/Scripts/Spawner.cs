using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    public GameObject applePrefab;    // 사과 프리팹
    public GameObject bugPrefab;      // 벌레 프리팹
    public float ApplespawnInterval = 0.5f; // 오브젝트 생성 간격 (초)
    public float BugspawnInterval = 0.8f; // 오브젝트 생성 간격 (초)
    public float minX = -6f; // 스폰 위치의 최소 x값
    public float maxX = 8.13f;  // 스폰 위치의 최대 x값
    bool isGameOver = false;

    private void Start()
    {
        // 일정 간격으로 함수 호출
        InvokeRepeating("SpawnApple", 0f, ApplespawnInterval);
        InvokeRepeating("SpawnBug", 0f, BugspawnInterval);
    }

    private void Update()
    {
        isGameOver = GameObject.FindWithTag("GamePlayer").GetComponent<MiniGamePlayer>().isGameOver;
    }
    // 랜덤 오브젝트 생성 함수
    void SpawnApple()
    {
        if (!isGameOver)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 5.8f, -3.1f);
            Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        }

    }

    void SpawnBug()
    {
        if (!isGameOver)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, 5.8f, -3.1f);
            Instantiate(bugPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
