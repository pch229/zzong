using TMPro;
using UnityEngine;

public class ShowingQuestText : MonoBehaviour
{
    GameObject player;

    Player playerObj;
    TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerObj = player.GetComponent<Player>();
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(playerObj.GetCurrentQuest() != null)
        {
            ObjData currentQuest = playerObj.GetCurrentQuest();

            if (currentQuest.GetNPCQuestState() == NPCQuestState.PROCESS_QUEST)
            {
                textMeshProUGUI.text = "Quest Number " + (currentQuest.GetCurrentQuest() + 1).ToString() + " : is processing from " + "NPC Number : " + currentQuest.GetNPCId();
            }
            else if (currentQuest.GetNPCQuestState() == NPCQuestState.SUCCESS_QUEST)
            {
                textMeshProUGUI.text = "Quest Number " + (currentQuest.GetCurrentQuest() + 1).ToString() + " : is done from " + "NPC Number : " + currentQuest.GetNPCId();
            }
        }
    }
}
