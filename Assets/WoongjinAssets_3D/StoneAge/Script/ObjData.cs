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
    int currentQuest;

    private void Awake()
    {
        currentQuest = 0;
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

    public void SetSuccessList(int index, bool value)
    {
        successList[index] = value;
    }
}
