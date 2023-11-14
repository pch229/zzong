using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("족장 할아버지와 대화하기", new int[] { 1000 }));
        questList.Add(20, new QuestData("긁개 제작하기", new int[] { 1000 }));
        questList.Add(30, new QuestData("돌도끼 제작하기", new int[] { 1000 }));
        questList.Add(40, new QuestData("습베찌르개 제작하기", new int[] { 1000 }));
        questList.Add(50, new QuestData("돌화살 제작하기", new int[] { 1000, 2000 }));
        questList.Add(60, new QuestData("돌괭이 제작하기", new int[] { 1000 }));
        questList.Add(70, new QuestData("엔딩", new int[] { 1000 }));

        questList.Add(80, new QuestData("재료수급", new int[] { 2000 }));
        /*
        questList.Add(10, new QuestData("족장 할아버지와 대화하기", new int[] {1000, 2000}));
        questList.Add(20, new QuestData("나무 채집하기", new int[] {1000, 2000}));
        */
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    // 현재 퀘스트의 questActionIndex 값을 반환하는 메서드
    public int GetQuestActionIndex()
    {
        return questActionIndex;
    }

    // 현재 퀘스트의 npcId 배열의 길이를 반환하는 메서드
    public int GetQuestNpcIdLength()
    {
        return questList[questId].npcId.Length;
    }

    public string CheckQuest(int id)
    {
        // 해당 NPC의 ID가 현재 퀘스트의 npcId와 일치하는 경우
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++; // questActionIndex를 증가시키고
            // 만약 모든 NPC를 방문했다면 다음 퀘스트로 넘어갑니다.
            if (questActionIndex == questList[questId].npcId.Length)
                NextQuest();
            // 현재 퀘스트의 이름을 반환합니다.
            return questList[questId].questName;
        }
        else
        {
            // 해당 NPC의 ID가 현재 퀘스트의 npcId와 일치하지 않는 경우 null을 반환합니다.
            return null;
        }
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;

        Debug.Log("다음으로 넘어가기");
    }
}
