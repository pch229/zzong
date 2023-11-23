using System.Collections;
using System.Collections.Generic;
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
    public GameObject joyStick;

    public QuestManager questManager;

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
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetActive(true);
        joyStick.SetActive(false);
        Debug.Log("Action()");
    }

    public void Talk(int id, bool isNPC)
    {

        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        //string talkData = talkManager.GetTalk(id, talkIndex);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

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
        Debug.Log(talkIndex);
    }
    /*
    IEnumerator TypeSentence(string sentence)
    {
        talkText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            talkText.text += letter;
            yield return new WaitForSeconds(0.15f);
        }
    }
    */
}
