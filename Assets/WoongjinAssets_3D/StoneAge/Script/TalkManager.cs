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
    public Gamemanager manager;

    public GameObject talkPanel;
    public GameObject joyStick;

    GameObject scanObject;


    void Awake()
    {
        scanObject = GameObject.Find("Player").GetComponent<Player>().scanObject;
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        nextButton.onClick.AddListener(() => NextTalk());
        outButton.onClick.AddListener(() => OutTalk());
    }


    void GenerateData()
    {

        // 인물NPC 대사

        // 족장
        talkData.Add(1000, new string[] { "족장 : 석기는 아직인가?",
                                          "족장 : 가만있어 보자... 물을 끓여야 되나..."});

        // 우가
        talkData.Add(2000, new string[] { "날씨가 좋군" });

        //몰?루
        talkData.Add(3000, new string[] { "열매 채집을 해야겠어!" });

        // 동물NPC 대사


        // 곰탱이
        talkData.Add(100, new string[] { "크아앙!",
                                         "...",
                                         "다음부터는 놀래는 척이라도 해달라곰."});

        // 개구락지
        talkData.Add(200, new string[] { "개굴, 개굴",
                                         "혹시 너, 금으로 만든 공을 가져다주지 않으련?",
                                         "아, 여기가 아닌가"});

        //토깽이
        talkData.Add(300, new string[] { "깊은 산 속",
                                         "옹~달~샘~",
                                         "네가 다 마셨냐?"});

        //고라니사촌
        talkData.Add(400, new string[] { "으악!",
                                         "내 뿔 멋있지 않니?",
                                         "아아, 먹는 건 아니니까 건드리지는 마"});

        //개
        talkData.Add(500, new string[] { "워우~~~",
                                         "...",
                                         "그냥 습관적으로 나오니까 무시해줘."});

        // Quest Talk
        // 퀘스트 번호 + NPC Id
        talkData.Add(10 + 1000, new string[] {  "족장 : "+ "아랑라알아랑랑라아랑랑라알아랑라아랑랑라알아랑랑랑랄아루ㅕ녀ㅓ미러모려ㅕ녀오뉴려노연러ㅠ너ㅠ어뉴ㅓ유넝ㄴㄴ",});

        talkData.Add(20 + 1000, new string[] {  "웅진 : 저... 이정도면...",
                                                "족장 : 오! 벌써 완성했나?",
                                                "족장 : 자네는 뭐든지 빠르구만!",
                                                "웅진 : 일단 보여주신거랑 최대한 비슷하게 해봤는데...",
                                                "완성된 주먹도끼를 건네준다.",
                                                "족장 : 그럼 어디 한 번 볼까?",
                                                "웅진 : (두근두근)",
                                                "족장 : 흠...",
                                                "웅진 : (두근두근)",
                                                "족장 : 음...",
                                                "웅진 : (표정이 안 좋아보인다...)",
                                                "웅진 : (나 이대로 고기가 되는 건가...)",
                                                "족장 : 흠냐...",
                                                "웅진 : (엄마, 아빠 사랑해요.전 여기까지인가봐요...)",
                                                "족장 : 아니! 자네!",
                                                "웅진 : (끝이다...)",
                                                "족장 : 훌륭한 솜씨구만!무리중에 두 번째로 멋진 주먹도끼야!",
                                                "웅진 : 그럼 첫 번째는?",
                                                "족장 : 당연히 나지.",
                                                "웅진 : 아, 넵.",
                                                "족장 : 그보다 자네 내 생각보다 더 쓸모있는 녀석이구만.",
                                                "족장 : 이 정도 주먹도끼면 아마 다른 무리원들도 자네를 인정할거야.",
                                                "웅진 : 감사합니다.",
                                                "족장 : 음... 그래서 말인데",
                                                "웅진 : 그래서 말인데?",
                                                "족장 : 자네가 우리에게 필요한 석기를 만들어 줬으면 좋겠어.",
                                                "족장 : 무리의 일원으로 받아드리겠다는 말이지!",
                                                "웅진 : 아, 말씀은 감사합니다. 하지만 저는...",
                                                "족장 : 싫은게야?",
                                                "웅진 : 아뇨 좋습니다.",
                                                "웅진 : (거슬렀다간 고기가 될지 몰라...)",
                                                "족장 : 그래 그래 그래야지! 앞으로 자네에게 석기제작을 맡기겠네." ,
                                                "족장 : 그런 의미에서 새로운 부탁을 하나 하지.",
                                                "웅진 : 어떤 부탁일까요?",
                                                "족장 : 사냥한 고기의 가죽을 벗겨야 하는데 이 주먹도끼로는 한계가 있는 것 같아.",
                                                "족장 : 뭔가 가죽을 잘 벗길 수 있는 석기가 있으면 손질하기 더 쉬울텐데...",
                                                "족장 : 자네가 한 번 만들어 보는 게 어때?",
                                                "웅진 : (아마도 긁개를 얘기하는 것 같아.)",
                                                "웅진 : (선생님한테 구석기 시대에도 효자손이 있었냐고 장난쳤던 게 기억이 나.)",
                                                "웅진 : 네, 맡겨주세요.",
                                                "족장에게 다듬어지지 않은 돌은 건네받았다.",
                                                "족장 : 아 참, 그럴리 없겠지만 자네가 만약 제작을 하다 돌을 깨뜨렸다면,",
                                                "웅진 : 잡아먹나요?",
                                                "족장 : 원래대로라면 그렇지. 하지만 다른 얘기를 하려고 했던거야.",
                                                "족장 : 저기()쪽에 보이는 덩치 있지? 저녀석이 재료를 모아오는 것을 담당하고 있어.",
                                                "족장 : 저 녀석한테 추가 재료를 받을 수 있어.",
                                                "웅진 : 아, 감사합니다.",
                                                "족장 : 너무 많이 깨뜨리면 잡아먹을거야.",
                                                "웅진 : (헙!)",
                                                "족장 : 장난이야 장난!그럼 어서 가서 석기를 만들어주게!" });
        /*
        talkData.Add(11 + 2000, new string[] { "재료를 받으러 왔니?",
                                               "여기 있어" });
        */
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10)) // Get First Talk
                return GetTalk(id - id % 100, talkIndex);
            //else
                //return GetTalk(id - id % 10, talkIndex); // Get Quest First Talk
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
       
            // manager.Action(scanObject);
            Debug.Log("NextTalk()");
        
        /*
        //이게 문제인듯
        if (manager.isAction)
        {
            // 퀘스트 체크를 먼저 수행
            manager.Talk(manager.scanObject.GetComponent<ObjData>().id, manager.scanObject.GetComponent<ObjData>());
            manager.questManager.CheckQuest(manager.scanObject.GetComponent<ObjData>().id);
        }
        */
    }

    void OutTalk()
    {
        talkPanel.SetActive(false);
        joyStick.gameObject.SetActive(true);
        // manager.talkIndex = 0;
    }

}
