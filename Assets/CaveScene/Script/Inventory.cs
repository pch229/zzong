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
    public Button[] ttButtons;
    public Button[] ganButtons;
    public Image[] RockAxes;
    public Image[] Slices;
    private Gamemanager gameManager;
    public Gamemanager.GameInstance[] ttEnumValues =
        {
        Gamemanager.GameInstance.RockAxe99,
        Gamemanager.GameInstance.RockAxe2,
        Gamemanager.GameInstance.RockAxe3,
    };
    private Gamemanager.GameInstance[] ganEnumValues =
       {
        Gamemanager.GameInstance.TTenSeokki1,
        Gamemanager.GameInstance.TTenSeokki2,
        Gamemanager.GameInstance.TTenSeokki3,
    };
    private Image activeImage;
    //private int[] activeRockAxesIndices;
    //private int[] activeSlicesIndices;
    void Start()
    {
        // gameManager = Gamemanager.Instance;
        //activeRockAxesIndices = new int[RockAxes.Length];
        //activeSlicesIndices = new int[Slices.Length];
        for (int i = 0; i < ttButtons.Length; i++)
        {
            int buttonIndex = i;
            ttButtons[i].onClick.AddListener(() => ttClick(buttonIndex));
        }
        for (int i = 0; i < ganButtons.Length; i++)
        {
            int buttonIndex = i;
            ganButtons[i].onClick.AddListener(() => ganClick(buttonIndex));
        }
    }
    public void ttClick(int buttonIndex)
    {
        gameManager.SetSelectedStone(ttEnumValues[buttonIndex]);
        //int activeSliceIndex = activeSlicesIndices[buttonIndex];
        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(false);
            //SetActiveImage(RockAxes[buttonIndex], true);
            // activeRockAxesIndices[buttonIndex] = buttonIndex;
        }
        /*else //if (Slices[buttonIndex].gameObject.activeSelf == true)
        {
            SetActiveImage(Slices[activeSliceIndex], false);
            SetActiveImage(RockAxes[buttonIndex], true);
            activeRockAxesIndices[buttonIndex] = buttonIndex;
            // RockAxes[buttonIndex].gameObject.SetActive(true);
        }*/
        activeImage = RockAxes[buttonIndex];
        activeImage.gameObject.SetActive(true);
        //activeSlicesIndices[buttonIndex] = -1;
    }
    void ganClick(int buttonIndex)
    {
        gameManager.SetSelectedStone(ganEnumValues[buttonIndex]);
        //int activeRockAxeIndex = activeRockAxesIndices[buttonIndex];
        if (activeImage != null)
        {
            activeImage.gameObject.SetActive(false);
            // SetActiveImage(Slices[buttonIndex], true);
            //activeSlicesIndices[buttonIndex] = buttonIndex;
        }
        /*else //if (RockAxes[buttonIndex].gameObject.activeSelf== true)
         {
             SetActiveImage(RockAxes[activeRockAxeIndex], false);
             SetActiveImage(Slices[buttonIndex], true);
             activeSlicesIndices[buttonIndex] = buttonIndex;
         }*/
        activeImage = Slices[buttonIndex];
        activeImage.gameObject.SetActive(true);
        // activeRockAxesIndices[buttonIndex] = -1;
    }
    /*void SetActiveImage(Image image, bool isActive)
    {
        if (image != null)
        {
            image.gameObject.SetActive(isActive);
        }
    }*/
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
