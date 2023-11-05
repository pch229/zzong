using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public Button nextButton;
    public Button outButton;
    public GameManager manager;

    public GameObject talkPanel;
    public GameObject joyStick;

    GameObject scanObject;


    void Awake()
    {
        scanObject = GameObject.Find("Player").GetComponent<Player_keyboard>().scanObject;
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        nextButton.onClick.AddListener(() => NextTalk());
        outButton.onClick.AddListener(() => OutTalk());
    }


    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕", 
                                          "나는 족장 할아버지야",
                                          "미션을 줄게"});
        talkData.Add(2000, new string[] { "날씨가 좋군" });
        talkData.Add(3000, new string[] { "열매 채집을 해야겠어!" });

        // Quest Talk
        // 퀘스트 번호 + NPC Id
        talkData.Add(10 + 1000, new string[] { "일어났구나", 
                                               "미션을 줄게" });
        talkData.Add(11 + 2000, new string[] { "재료를 받으러 왔니?",
                                               "여기 있어" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10)) // Get First Talk
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex); // Get Quest First Talk
        }
        Debug.Log(id + talkIndex);
        // 마지막 대화에서 다음 버튼 안 보이게
        if (talkIndex == talkData[id].Length - 1)
            nextButton.gameObject.SetActive(false);
        else
            nextButton.gameObject.SetActive(true);

        
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

            

    }

    void NextTalk()
    {
        //이게 문제인듯
        if (manager.isAction)
        {
            // 퀘스트 체크를 먼저 수행
            manager.Talk(manager.scanObject.GetComponent<ObjData>().id, manager.scanObject.GetComponent<ObjData>());
            manager.questManager.CheckQuest(manager.scanObject.GetComponent<ObjData>().id);
        }
    }

    void OutTalk()
    {
        talkPanel.SetActive(false);
        joyStick.gameObject.SetActive(true);
    }

}
