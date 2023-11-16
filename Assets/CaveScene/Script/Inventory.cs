using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;


public class Inventory : MonoBehaviour
{
    public GameObject[] backgroundArr = {};
    public Gamemanager gameManager;
    public GameObject inventory;
    private GameInstance[] stoneEnumArr = {
        GameInstance.TtenSeokki1,
        GameInstance.TtenSeokki2,
        GameInstance.TtenSeokki3,
        GameInstance.GanSeokki1,
        GameInstance.GanSeokki2,
        GameInstance.GanSeokki3,
    };
    public Image currentImage;
    public Image[] activeImageArr;
    Player playerScript;

    void Start()
    {
        gameManager = FindObjectOfType<Gamemanager>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>() ;
    }
    public void stoneClick(int buttonIndex)
    {
        if(currentImage != null)
        {
            currentImage.transform.gameObject.SetActive(false);
        }
        gameManager.SetSelectedStone(stoneEnumArr[buttonIndex]);
        currentImage = activeImageArr[buttonIndex];
        currentImage.transform.gameObject.SetActive(true);
    }
   /* public void stoneClick2()
    {
        if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.TtenSeokki1)
        {
            Debug.Log(123);
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.TtenSeokki2)
        {
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.TtenSeokki3)
        {
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.GanSeokki1)
        {
            inventory.gameObject.SetActive(true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance .GanSeokki2)
        {
            inventory.gameObject.SetActive (true);
        }
        else if(gameManager.GetSelectedStone() == Gamemanager.GameInstance.GanSeokki3)
        {
            inventory.gameObject.SetActive(true);
        }
    }
   */
    public void makeclick()
    {
        if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki1)
        {
            backgroundArr[0].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki2)
        {
            backgroundArr[1].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.TtenSeokki3)
        {
            backgroundArr[2].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki1)
        {
            backgroundArr[3].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki2)
        {
            backgroundArr[4].gameObject.SetActive(true);
        }
        else if (gameManager.GetSelectedStone() == GameInstance.GanSeokki3)
        {
            backgroundArr[5].gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    public void CloseInven()
    {
        gameObject.SetActive(false);
        playerScript.SetIsPlayerMaking(false);
    }
}
