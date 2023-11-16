using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StonePool : MonoBehaviour
{
    [SerializeField] GameObject[] ttenSeokgiPrefabs;
    [SerializeField] GameObject[] ganSeokgiPrefabs;
    [SerializeField] GameObject[] uiPrefabs;

    Gamemanager gameManager;
    GameObject[] ttenSeokgiPool;
    GameObject[] ganSeokgiPool;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
    }

    void Start()
    {
        ttenSeokgiPool = new GameObject[ttenSeokgiPrefabs.Length];

        for (int i = 0; i < ttenSeokgiPool.Length; i++)
        {
            ttenSeokgiPool[i] = Instantiate(ttenSeokgiPrefabs[i], transform);

            if (i == (int)gameManager.GetSelectedStone())
            {
                ttenSeokgiPool[i].SetActive(true);
            }
            else
            {
                ttenSeokgiPool[i].SetActive(false);
            }
        }

        ganSeokgiPool = new GameObject[ganSeokgiPrefabs.Length];

        for (int i = 0; i < ganSeokgiPool.Length; i++)
        {
            ganSeokgiPool[i] = Instantiate(ganSeokgiPrefabs[i], transform);

            if (i + ttenSeokgiPool.Length == (int)gameManager.GetSelectedStone())
            {
                ganSeokgiPool[i].SetActive(true);
            }
            else
            {
                ganSeokgiPool[i].SetActive(false);
            }
        }

        for (int i = 0; i < uiPrefabs.Length; i++)
        {
            if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki1
                || gameManager.GetSelectedStone() == GameInstance.TtenSeokki2
                || gameManager.GetSelectedStone() == GameInstance.TtenSeokki3)
            {
                uiPrefabs[0].SetActive(true);
            }
            else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki1
                || gameManager.GetSelectedStone() == GameInstance.GanSeokki2
                || gameManager.GetSelectedStone() == GameInstance.GanSeokki3)
            {
                uiPrefabs[1].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
