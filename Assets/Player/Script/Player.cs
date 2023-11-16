using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Gamemanager gameManager;
    public GameObject scanObject;
    public Button talkButton;
    public Button makebutton;

    ObjData objData;

    public ObjData currentQuest;
    public GameObject inventoryCanvas;

    bool isMaking = false;

    void Awake()
    {
        // talkButton.onClick.AddListener(() => TalkStart());
        inventoryCanvas = GameObject.FindWithTag("InvenSingleTon");
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, 0.7f))
        {
            if (rayHit.collider.tag == "NPC")
            {
                scanObject = rayHit.collider.gameObject;
                objData = scanObject.GetComponent<ObjData>();
                talkButton.gameObject.SetActive(true);
            }
        }
        else
        {
            scanObject = null;
            // talkButton.gameObject.SetActive(false);
        }
    }

    public void SetCurrentQuest(ObjData obj)
    {
        currentQuest = obj;
    }

    public ObjData GetCurrentQuest()
    {
        return currentQuest;
    }

    void TalkStart()
    {
        if (scanObject != null)
        {
            gameManager.Action(scanObject);
        }
    }

    public GameObject GetScanObject()
    {
        return scanObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inven"))
        {
            InvenCanvas inventoryCanvasObj = inventoryCanvas.GetComponent<InvenCanvas>();
            inventoryCanvasObj.SetActiveInven(true);
            isMaking = true;
        }
    }

    public void SetIsPlayerMaking(bool state)
    {
        isMaking = state;
    }

    public bool GetIsPlayerMaking()
    {
        return isMaking;
    }
}