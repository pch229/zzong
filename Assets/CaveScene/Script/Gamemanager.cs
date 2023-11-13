using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public enum GameInstance
    {
        TtenSeokki1,
        TtenSeokki2,
        TtenSeokki3,
        GanSeokki1,
        GanSeokki2,
        GanSeokki3,
        none,
    }
    public GameInstance selectedStone;

    void Awake()
    {
        int gameManagerCount = FindObjectsOfType<Gamemanager>().Length;

        if (gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        selectedStone = GameInstance.none;
    }
    public void SetSelectedStone(GameInstance stone)
    {
        selectedStone = stone;
    }

    public GameInstance GetSelectedStone()
    {
        return selectedStone;
    }
}
