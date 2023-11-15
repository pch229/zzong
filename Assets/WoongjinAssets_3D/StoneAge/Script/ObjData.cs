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
    public int id;
    public bool isNPC;
    public NPCQuestState npcQuestState = NPCQuestState.NONE;
    public string[] questTitleArr;
    public bool[] successArr;
    public int currentQuest;

    Player processingPlayer;

    private void Awake()
    {
        questTitleArr = new string[6];
        // questTitleArr[0] = "족장에게 말걸기";
        questTitleArr[0] = "Making scratches"; // "긁개 제작하기";
        questTitleArr[1] = "Making a stone axe"; // "돌도끼 제작하기";
        questTitleArr[2] = "Making a Sumbetjigae"; // "습베찌르개 제작하기";
        questTitleArr[3] = "Making a Stone Arrow"; // "돌화살 제작하기";
        questTitleArr[4] = "Making a Pickpick"; // "돌괭이 제작하기";
        questTitleArr[5] = "Ending"; // "엔딩";

        successArr = new bool[questTitleArr.Length];

        for(int i = 0; i < successArr.Length; ++i)
        {
            successArr[i] = false;
        }

        currentQuest = 0;
    }

    public int GetNPCId()
    {
        return id;
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

    public string GetQuestTitle(int index)
    {
        return questTitleArr[index];
    }

    public void SetProcessingPlayer(Player player)
    {
        processingPlayer = player;
    }

    public void SetSuccessArr(int index, bool isFinsh)
    {
        successArr[index] = isFinsh;
    }
}
