using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public enum GameInstance
    {
        RockAxe99,
        RockAxe2,
        RockAxe3,
        TTenSeokki1,
        TTenSeokki2,
        TTenSeokki3,
        none,
    }
    private static Gamemanager instance;
    public GameInstance selectedStone;

    void Awake()
    {
        int gameManagerCount = FindObjectsOfType<GameManager>().Length;

        if(gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //public static Gamemanager Instance
    //{
    //    get
    //    {
    //        if(instance == null)
    //        {
    //            instance = FindObjectOfType<Gamemanager>();
    //            if(instance != null )
    //            {
    //                GameObject obj = new GameObject("Gamemanager");
    //                instance = obj.AddComponent<Gamemanager>();
    //            }    
    //        }
    //        return instance;
    //    }
    //}
   public void SetSelectedStone(GameInstance stone)
    {
        Debug.Log(stone);
        selectedStone = stone;
    }

    public GameInstance GetSelectedStone()
    {
        return selectedStone;
    }
}
