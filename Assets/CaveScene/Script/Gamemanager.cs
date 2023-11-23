using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

public class Gamemanager : MonoBehaviour
{
    public Button book1;
    public Button book2;
    public Button book3;
    public GameObject Close1;
    public GameObject Close2;
    public GameObject Close3;
    public GameObject MasterClose;
    public GameObject CloseNotice;
    public GameObject RecommendedBook;
    public Image Complete1;
    public Image Complete2;
    public Image Complete3;
    public Image NoticeScene;
    public GameObject Scroll1;
    public GameObject Scroll2;
    public GameObject Scroll3;
    //public GameObject[] Scrolls;
    public ScrollRect scrollRect1;
    public ScrollRect scrollRect2;
    public ScrollRect scrollRect3;
    public float scrollEndThreshold = 0.9f;
    public GameObject inventory;
    public GameObject inven6;
    public ItemScript itemScript;
    public GameInstance selectedStone;

    public GameObject talkPanel;
    
    public TalkManager talkManager;
    public QuestManager questManager;
    //public Player playerObj;
    //public GameObject player;
    //public GameObject characterUICanvasObj;

    private void OnEnable()
    {
        
            // "On Value Changed" �̺�Ʈ�� �ݹ� �Լ� ����
            scrollRect1.onValueChanged.AddListener(OnScrollValueChanged);
            scrollRect2.onValueChanged.AddListener(OnScrollValueChanged);
            scrollRect3.onValueChanged.AddListener(OnScrollValueChanged);
        
    
        // "On Value Changed" �̺�Ʈ�� �ݹ� �Լ� ����
       // scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
    }

    private void OnDisable()
    {
        // ��ũ��Ʈ�� ��Ȱ��ȭ�� �� �̺�Ʈ ����
        scrollRect1.onValueChanged.RemoveListener(OnScrollValueChanged);
        scrollRect2.onValueChanged.RemoveListener(OnScrollValueChanged);
        scrollRect3.onValueChanged.RemoveListener(OnScrollValueChanged);
    }
    
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

    private void Update()
    {
        float verticalScrollPosition1 = scrollRect1.verticalNormalizedPosition;
        float verticalScrollPosition2 = scrollRect2.verticalNormalizedPosition;
        float verticalScrollPosition3 = scrollRect3.verticalNormalizedPosition;
        if (verticalScrollPosition1 <= 1 - scrollEndThreshold)
        {
            Close1.gameObject.SetActive(true);
        }
        if (verticalScrollPosition2 <= 1 - scrollEndThreshold)
        {
            Close2.gameObject.SetActive(true);
        }
        if (verticalScrollPosition3 <= 1 - scrollEndThreshold)
        {
            Close3.gameObject.SetActive(true);
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("씬재로드");
    }

    public void SetSelectedStone(GameInstance stone)
    {
        selectedStone = stone;
    }

    public GameInstance GetSelectedStone()
    {
        return selectedStone;
    }

    //public void Action(GameObject scanObj)
    //{
    //    // scanObject = scanObj;
    //    ObjData objData = scanObj.GetComponent<ObjData>();
    //    talkManager.Talk(objData.GetNPCId(), objData.GetIsNPC(), objData.GetNPCQuestState(), objData.GetCurrentQuest());

    //    talkPanel.SetActive(isAction);
    //}

    //public void Talk(int id, bool isNPC, NPCQuestState state, int currentQuest)
    //{
    //    string talkData = "";

    //    if (state == NPCQuestState.NONE)
    //    {
    //        talkData = talkManager.GetTalk(id, 0);
    //    }
    //    else if (state == NPCQuestState.HAVE_QUEST)
    //    {
    //        talkData = talkManager.GetTalk(id + (int)state + (10 * (currentQuest + 1)), talkIndex); // 1000 + 0 + 10 = 1010
    //    }
    //    else if (state == NPCQuestState.SUCCESS_QUEST)
    //    {
    //        talkData = talkManager.GetTalk(id + (int)state + (10 * (currentQuest + 1)), talkIndex); // 1000 + 0 + 10 = 1010
    //    }
    //    else if (state == NPCQuestState.PROCESS_QUEST)
    //    {
    //        talkData = talkManager.GetTalk(id, talkIndex);
    //    }
    //    ////Set Talk Data
    //    //int questTalkIndex = questManager.GetQuestTalkIndex(id);
    //    ////string talkData = talkManager.GetTalk(id, talkIndex);
    //    //string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

    //    // End Talk
    //    if (talkData == null)
    //    {
    //        isAction = false;
    //        Debug.Log("isAction = false");

    //        talkIndex = 0;
    //        Debug.Log(questManager.CheckQuest(id));

    //        return;
    //    }

    //    if (isNPC)
    //    {
    //        talkText.text = talkData;
    //    }
    //    else
    //    {
    //        talkText.text = talkData;
    //    }
    //    isAction = true;
    //    talkIndex++;
    //}

    //public void SetSuccessArr()
    //{
    //    ObjData currentQuestObj = playerObj.GetCurrentQuest();
    //    currentQuestObj.SetSuccessList(currentQuestObj.GetCurrentQuest(), true);

    //    if (currentQuestObj.GetNPCQuestState() == NPCQuestState.PROCESS_QUEST)
    //    {
    //        currentQuestObj.SetNPCQuestState(NPCQuestState.SUCCESS_QUEST);
    //    }
    //}

    public void OnScrollValueChanged(Vector2 value)
    {
        // ���� ��ũ�� ���� Ư�� �Ӱ谪 ���Ϸ� �������ٸ�
        if (value.y <= 1 - scrollEndThreshold)
        {
            Debug.Log("911");
            // ��ũ���� �������Ƿ� SetActive(false) ȣ��
            //Close1.SetActive(true);
        }
    }

    public void ItemClick()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 0; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 0 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick2()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 1; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 1 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI1();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick3()
    {
       // inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 2; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 2 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI2();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick4()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 3; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 3 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI3();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick5()
    {
       // inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 4; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 4 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI4();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick6()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 5; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 5 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI5();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void ItemClick7()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript���� ������ ����Ʈ ��������
            var itemList = itemScript.GetItems();

            // �������� quantity ������Ű��
            int itemIndexToUpdate = 6; // ���� ���, ù ��° �������� quantity�� ������Ű�� �ʹٸ� index 0�� ����մϴ�.

            if (itemIndexToUpdate >= 6 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
                itemList[itemIndexToUpdate].quantity++; // Ư�� �������� quantity�� 1 ������ŵ�ϴ�.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI ����
            itemScript.UpdateUI6();
        }
        else
        {
            Debug.LogError("ItemScript�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    public void BookClick3()
    {
        Scroll3.gameObject.SetActive(true);
    }
   public void BookClick2()
    {
        Scroll2.gameObject.SetActive(true);
    }
   public void BookClick1()
    {
        Scroll1.gameObject.SetActive(true);
    }
    public void CloseClick2()
    {
            NoticeScene.gameObject.SetActive(false);
    }
    public void CloseClick()
    {
        if (scrollRect1.gameObject.activeSelf == true && scrollRect2.gameObject.activeSelf == false && scrollRect3.gameObject.activeSelf == false)
        {
            scrollRect1.gameObject.SetActive(false);
            Complete1.gameObject.SetActive(true);
            inven6.gameObject.SetActive(true);
        }
        else if (scrollRect1.gameObject.activeSelf == false && scrollRect2.gameObject.activeSelf == true && scrollRect3.gameObject.activeSelf == false)
        {
            scrollRect2.gameObject.SetActive(false);
            Complete2.gameObject.SetActive(true);
            inven6.gameObject.SetActive(true);
        }
        else if(scrollRect1.gameObject.activeSelf == false && scrollRect2.gameObject.activeSelf == false && scrollRect3.gameObject.activeSelf == true)
        {
            scrollRect3.gameObject.SetActive(false);
            Complete3.gameObject.SetActive(true);
            inven6.gameObject.SetActive(true);
        }
        else if(Complete1.gameObject.activeSelf == true &&  Complete2.gameObject.activeSelf == true && Complete3.gameObject.activeSelf == true)
        {
            MasterClose.gameObject.SetActive(true);
            RecommendedBook.gameObject.SetActive(false);
            inven6.gameObject .SetActive(true);
        }
       
    }
}
