using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    success,
    fail,
    none
}

public class MakingStoneManager : MonoBehaviour
{
    [SerializeField] GameObject successModalObj;
    [SerializeField] GameObject failModalObj;
    [SerializeField] int successRate;

    Gamemanager gameManager;
    GameObject[] ttenSeokgiPool;
    GameObject[] ganSeokgiArrPool;

    public GameObject ttenSeokgiGroup;
    public GameObject ganSeokgiGroup;

    GameState gameState = GameState.none;
    int rate = 0;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<Gamemanager>();
    }

    void Update()
    {
        if (gameState == GameState.success)
        {
            if (rate < (successRate / 10))
            {
                successModalObj.SetActive(true);
            }
            else
            {
                gameState = GameState.fail;
            }
        }
        else if (gameState == GameState.fail)
        {
            failModalObj.SetActive(true);
        }
    }

    public void SetGameResult(GameState result)
    {
        gameState = result;
    }

    public void SetSuccessRate()
    {
        rate = Random.Range(0, 10);
    }

    public GameState GetGameResult()
    {
        return gameState;
    }
}
