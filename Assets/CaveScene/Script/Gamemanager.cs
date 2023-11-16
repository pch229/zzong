using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

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
        
    private void OnEnable()
    {
        
            // "On Value Changed" 이벤트에 콜백 함수 연결
            scrollRect1.onValueChanged.AddListener(OnScrollValueChanged);
            scrollRect2.onValueChanged.AddListener(OnScrollValueChanged);
            scrollRect3.onValueChanged.AddListener(OnScrollValueChanged);
        
    
        // "On Value Changed" 이벤트에 콜백 함수 연결
       // scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
    }

    private void OnDisable()
    {
        // 스크립트가 비활성화될 때 이벤트 해제
        scrollRect1.onValueChanged.RemoveListener(OnScrollValueChanged);
        scrollRect2.onValueChanged.RemoveListener(OnScrollValueChanged);
        scrollRect3.onValueChanged.RemoveListener(OnScrollValueChanged);
    }
    public void OnScrollValueChanged(Vector2 value)
    {
        // 만약 스크롤 값이 특정 임계값 이하로 내려갔다면
        if (value.y <= 1 - scrollEndThreshold)
        {
            Debug.Log("911");
            // 스크롤이 끝났으므로 SetActive(false) 호출
            //Close1.SetActive(true);
        }
    }
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

    private void Update()
    {
         float verticalScrollPosition1 = scrollRect1.verticalNormalizedPosition;
         float verticalScrollPosition2 = scrollRect2.verticalNormalizedPosition;
         float verticalScrollPosition3 = scrollRect3.verticalNormalizedPosition;
         if (verticalScrollPosition1 <= 1 - scrollEndThreshold)
         {
             Close1.gameObject.SetActive(true);
         }
         if(verticalScrollPosition2 <= 1 - scrollEndThreshold)
        {
            Close2.gameObject.SetActive(true);
        }
         if(verticalScrollPosition3 <= 1 - scrollEndThreshold)
        {
            Close3.gameObject.SetActive(true);
        }
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
    public void SetSelectedStone(GameInstance stone)
    {
        selectedStone = stone;
    }

    public GameInstance GetSelectedStone()
    {
        return selectedStone;
    }
    public ItemScript itemScript;
    public void ItemClick()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 0; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 0 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
        }
    }
    public void ItemClick2()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 1; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 1 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI1();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
        }
    }
    public void ItemClick3()
    {
       // inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 2; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 2 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI2();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
        }
    }
    public void ItemClick4()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 3; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 3 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI3();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
        }
    }
    public void ItemClick5()
    {
       // inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 4; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 4 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI4();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
        }
    }
    public void ItemClick6()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 5; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 5 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI5();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
        }
    }
    public void ItemClick7()
    {
        //inventory.gameObject.SetActive(true);
        inven6.gameObject.SetActive(false);
        if (itemScript != null)
        {
            Debug.Log(123);
            // ItemScript에서 아이템 리스트 가져오기
            var itemList = itemScript.GetItems();

            // 아이템의 quantity 증가시키기
            int itemIndexToUpdate = 6; // 예를 들어, 첫 번째 아이템의 quantity를 증가시키고 싶다면 index 0을 사용합니다.

            if (itemIndexToUpdate >= 6 && itemIndexToUpdate < itemList.Count)
            {
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
                itemList[itemIndexToUpdate].quantity++; // 특정 아이템의 quantity를 1 증가시킵니다.
            }
            else
            {
                Debug.LogError("Invalid item index or itemList is empty!");
            }

            // UI 갱신
            itemScript.UpdateUI6();
        }
        else
        {
            Debug.LogError("ItemScript가 할당되지 않았습니다.");
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
