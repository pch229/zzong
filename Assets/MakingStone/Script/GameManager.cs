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

    GameState makeResult = GameState.none;

    // Update is called once per frame
    void Update()
    {
        if (makeResult == GameState.success)
        {
            successModalObj.SetActive(true);
        }
        else if (makeResult == GameState.fail)
        {
            failModalObj.SetActive(true);
        }
    }

    public void SetGameResult(GameState result)
    {
        makeResult = result;
    }

    public GameState GetGameResult()
    {
        return makeResult;
    }
}
