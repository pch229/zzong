using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCQuestState
{
    HAVE_QUEST,
    SUCCESS_QUEST,
    PROCESS_QUEST,
    NONE
}

public class ObjData : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] bool isNPC;
    [SerializeField] List<bool> successList;

    public NPCQuestState npcQuestState = NPCQuestState.NONE;
    public int currentQuest;
    GameObject processingPlayer;
    GameObject talkManagerObj;

    TalkManager talkManagerScript;

    private void Awake()
    {
        talkManagerObj = GameObject.FindWithTag("TalkManager");
        talkManagerScript = talkManagerObj.GetComponent<TalkManager>();
        currentQuest = 0;
    }

    void FixedUpdate()
    {
        //RaycastHit rayHit;

        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), transform.forward, Color.red);
        //if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), transform.forward, out rayHit, 10f))
        //{
        //    if (rayHit.collider.tag == "Player")
        //    {
        //        Debug.Log("µé¾î¿È");
        //        Player playerScript = rayHit.collider.gameObject.GetComponent<Player>();
        //        playerScript.SetScanObject(gameObject);
        //        playerScript.SetCurrentQuest(gameObject.GetComponent<ObjData>());
        //        talkManagerScript.ToggleTalkButton(true);
        //    }
        //}
        //else
        //{
        //    talkManagerScript.ToggleTalkButton(false);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player playerScript = other.GetComponent<Player>();
            playerScript.SetScanObject(gameObject);
            talkManagerScript.ToggleTalkButton(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player playerScript = other.GetComponent<Player>();
            playerScript.SetScanObject(null);
            talkManagerScript.ToggleTalkButton(false);
        }
    }

    public int GetNPCId()
    {
        return id;
    }

    public bool GetIsNPC()
    {
        return isNPC;
    }

    public NPCQuestState GetNPCQuestState()
    {
        return npcQuestState;
    }

    public void SetNPCQuestState(NPCQuestState state)
    {
        npcQuestState = state;
    }

    public int GetCurrentQuest()
    {
        return currentQuest;
    }

    public void IncreaseCurrentQuest()
    {
        currentQuest++;
    }

    public void AddSuccessList()
    {
        successList.Add(false);
    }

    public void SetProcessingPlayer(GameObject player)
    {
        processingPlayer = player;
    }

    public void SetSuccessArr()
    {
        successList[currentQuest] = true;

        if (npcQuestState == NPCQuestState.PROCESS_QUEST)
        {
            npcQuestState = NPCQuestState.SUCCESS_QUEST;
        }
    }
}
