using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    
    public GameObject questionMark; // 물음표 오브젝트
    public GameObject exclamationMark; // 느낌표 오브젝트

    public QuestManager questManager; // QuestManager에 대한 참조

    // NPC의 ID
    public int npcId;

    void Update()
    {
        // 현재 NPC가 진행 중인 퀘스트와 관련이 있는지 확인
        bool isRelatedToCurrentQuest = questManager.CheckQuest(npcId) != null;
        // 현재 NPC가 진행 중인 퀘스트를 완료했는지 확인
        bool hasCompletedCurrentQuest = questManager.GetQuestActionIndex() == questManager.GetQuestNpcIdLength();

        if (isRelatedToCurrentQuest)
        {
            if (hasCompletedCurrentQuest)
            {
                // 퀘스트 완료: 물음표 활성화, 느낌표 비활성화
                questionMark.SetActive(true);
                exclamationMark.SetActive(false);
            }
            else
            {
                // 퀘스트 진행 중: 물음표 비활성화, 느낌표 활성화
                questionMark.SetActive(false);
                exclamationMark.SetActive(true);
            }
        }
        else
        {
            // 현재 퀘스트와 관련이 없는 경우: 둘 다 비활성화
            questionMark.SetActive(false);
            exclamationMark.SetActive(false);
        }
    }
}