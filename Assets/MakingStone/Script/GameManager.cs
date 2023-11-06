using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    success,
    fail,
    none
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject successModalObj;
    [SerializeField] GameObject failModalObj;
    [SerializeField] int successRate;

    GameState gameState = GameState.none;
    int rate = 0;

    void Update()
    {
        if (gameState == GameState.success)
        {
            if(rate < (successRate / 10))
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
