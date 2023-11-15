using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBranch : MonoBehaviour
{
    public GameObject Branch;  
    public Terrain terrain;       
    public int numberOfItems = 100;    

    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            // Terrain의 경계 내에서 랜덤한 위치를 찾기.
            float x = Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
            float z = Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);

            // 랜덤한 위치에 해당하는 Terrain의 높이를 찾기.
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            // 랜덤한 위치에 아이템 Prefab을 인스턴스화.
            Instantiate(Branch, new Vector3(x, y+0.2f, z), Quaternion.identity);
        }
    }
}
