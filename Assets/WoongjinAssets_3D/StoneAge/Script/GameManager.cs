using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;

    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public GameObject joyStick;

    public QuestManager questManager;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetActive(isAction);
        joyStick.gameObject.SetActive(!isAction);
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
            StartCoroutine(TypeSentence(talkData));
        }
        else 
        {
            StartCoroutine(TypeSentence(talkData));
        }
        isAction = true;
        talkIndex++;
        Debug.Log(talkIndex);
    }

    // 글자 천천히 나오게
    IEnumerator TypeSentence(string sentence)
    {
        talkText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            talkText.text += letter;
            yield return new WaitForSeconds(0.1f); // 이 값은 적절하게 조절하여 속도를 변경할 수 있습니다.
        }
    }
}
