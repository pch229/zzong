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

    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetActive(isAction);
        joyStick.gameObject.SetActive(!isAction);
    }

        public void Talk(int id, bool isNPC)
        {
            //Set Talk Data
            int questTalkIndex = questManager.GetQuestTalkIndex(id);
            string talkData = talkManager.GetTalk(id+ questTalkIndex, talkIndex);

            // End Talk
            if (talkData == null)
            {
                isAction = false;
                talkIndex = 0;
                Debug.Log(questManager.CheckQuest(id));
                return;
            }

            //Continue Talk
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

        public void OnClick()
        {
            isAction = false;
        }
    
}
