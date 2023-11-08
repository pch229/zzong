using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Button tt;
    public Button gan;
    public Image RockAxe;
    public Image Slice;
    private Gamemanager gameManager;
    public void ttClick()
    {
        gameManager.SetSelectedStone(Gamemanager.GameInstance.RockAxe1);
        if (Slice.gameObject.activeSelf == false)
        {
            RockAxe.gameObject.SetActive(true);
        }
        else if (Slice.gameObject.activeSelf == true)
        {
            Slice.gameObject.SetActive(false);
            RockAxe.gameObject.SetActive(true);
        }
       
    }
    public void ganClick()
    {
        gameManager.SetSelectedStone(Gamemanager.GameInstance.TTenSeokki1);
        if(RockAxe.gameObject.activeSelf == false)
        {
            Slice.gameObject.SetActive(true);
        }
        else if(RockAxe.gameObject.activeSelf== true)
        {
            RockAxe.gameObject.SetActive(false);
            Slice.gameObject.SetActive(true);
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
       gameManager = Gamemanager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
