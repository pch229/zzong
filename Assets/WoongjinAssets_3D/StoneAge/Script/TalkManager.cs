using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public Button nextButton;
    public Button outButton;
    public GameManager manager;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();

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
        
        if (talkIndex == talkData[id].Length)
            return null;
        else 
            return talkData[id][talkIndex];
    }

    //public void OnClick()
    //{
    //    if (manager.isAction)
    //    {
    //        //manager.TalkNext();
    //    }
    //}
}
