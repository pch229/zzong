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
    public GameObject inventory;
    public GameObject Canvas;
    public Button makebutton;

    ObjData objData;

    public ObjData currentQuest;

    void Awake()
    {
        talkButton.onClick.AddListener(() => TalkStart());
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
            talkButton.gameObject.SetActive(false);
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
            inventory.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
        }
    }
}