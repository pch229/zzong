using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject scanObject;
    public Button makebutton;

    public ObjData currentQuest;
    public GameObject inventoryCanvas;

    bool isMaking = false;

    void Awake()
    {
        // talkButton.onClick.AddListener(() => TalkStart());
        talkManager = GameObject.FindWithTag("TalkManager").GetComponent<TalkManager>();
        inventoryCanvas = GameObject.FindWithTag("InvenSingleTon");
    }

    void FixedUpdate()
    {
        //RaycastHit rayHit;

        //if (Physics.Raycast(transform.position, transform.forward, out rayHit, 0.7f))
        //{
        //    if (rayHit.collider.tag == "NPC")
        //    {
        //        scanObject = rayHit.collider.gameObject;
        //        objData = scanObject.GetComponent<ObjData>();
        //        talkButtonObj.gameObject.SetActive(true);
        //    }
        //}
        //else
        //{
        //    scanObject = null;

        //    if(talkButtonObj != null)
        //        talkButtonObj.gameObject.SetActive(false);
        //}
    }

    public void SetCurrentQuest(ObjData obj)
    {
        currentQuest = obj;
    }

    public ObjData GetCurrentQuest()
    {
        return currentQuest;
    }

    public void TalkStart()
    {
        if (scanObject != null)
        {
            talkManager.Action(scanObject);
        }
    }

    public void SetScanObject(GameObject npc)
    {
        scanObject = npc;
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
        else if(other.CompareTag("Portal"))
        {
            SceneManager.LoadScene("4_Forest");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("inven"))
        {
            InvenCanvas inventoryCanvasObj = inventoryCanvas.GetComponent<InvenCanvas>();
            inventoryCanvasObj.SetActiveInven(false);
            isMaking = false;
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