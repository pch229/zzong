using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public enum GameInstance
    {
        RockAxe1,
        RockAxe2,
        RockAxe3,
        TTenSeokki1,
        TTenSeokki2,
        TTenSeokki3,
        none,
    }
    private static Gamemanager instance;
    private GameInstance selectedStone;

    public static Gamemanager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Gamemanager>();
                if(instance != null )
                {
                    GameObject obj = new GameObject("Gamemanager");
                    instance = obj.AddComponent<Gamemanager>();
                }    
            }
            return instance;
        }
    }
   public void SetSelectedStone(GameInstance stone)
    {
        selectedStone = stone;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
