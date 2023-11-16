using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public enum GameInstance
    {
        TtenSeokki1,
        TtenSeokki2,
        TtenSeokki3,
        GanSeokki1,
        GanSeokki2,
        GanSeokki3,
        none,
    }
    public GameInstance selectedStone;

    public TalkManager talkManager;
    public GameObject talkPanel;

    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public QuestManager questManager;
    public GameObject player;

    public Player playerObj;

    void Awake()
    {
        int gameManagerCount = FindObjectsOfType<Gamemanager>().Length;

        if (gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        playerObj = player.GetComponent<Player>();
    }

    void Start()
    {
        selectedStone = GameInstance.none;
    }
    public void SetSelectedStone(GameInstance stone)
    {
        selectedStone = stone;
    }

    public GameInstance GetSelectedStone()
    {
        return selectedStone;
    }

    public void Action(GameObject scanObj)
    {
        // scanObject = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.GetNPCId(), objData.GetIsNPC(), objData.GetNPCQuestState(), objData.GetCurrentQuest());

        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, bool isNPC, NPCQuestState state, int currentQuest)
    {
        string talkData = "";

        if (state == NPCQuestState.NONE)
        {
            talkData = talkManager.GetTalk(id, 0);
        }
        else if (state == NPCQuestState.HAVE_QUEST)
        {
            talkData = talkManager.GetTalk(id + (int)state + (10 * (currentQuest + 1)), talkIndex); // 1000 + 0 + 10 = 1010
        }
        else if (state == NPCQuestState.SUCCESS_QUEST)
        {
            talkData = talkManager.GetTalk(id + (int)state + (10 * (currentQuest + 1)), talkIndex); // 1000 + 0 + 10 = 1010
        }
        else if (state == NPCQuestState.PROCESS_QUEST)
        {
            talkData = talkManager.GetTalk(id, talkIndex);
        }
        ////Set Talk Data
        //int questTalkIndex = questManager.GetQuestTalkIndex(id);
        ////string talkData = talkManager.GetTalk(id, talkIndex);
        //string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        // End Talk
        if (talkData == null)
        {
            isAction = false;
            Debug.Log("isAction = false");

            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));

            return;
        }

        if (isNPC)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }

    public void SetSuccessArr()
    {
        ObjData currentQuestObj = playerObj.GetCurrentQuest();
        currentQuestObj.SetSuccessList(currentQuestObj.GetCurrentQuest(), true);

        if (currentQuestObj.GetNPCQuestState() == NPCQuestState.PROCESS_QUEST)
        {
            currentQuestObj.SetNPCQuestState(NPCQuestState.SUCCESS_QUEST);
        }
    }
}
