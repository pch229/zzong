using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public struct QuestDataStruct
{
    public string[] questArr;
    public bool hasSuccessComment;
}

public class TalkManager : MonoBehaviour
{
    Dictionary<int, QuestDataStruct> talkData;

    public Button nextButton;
    public Button outButton;
    public Gamemanager manager;

    public GameObject talkPanel;
    public TextMeshProUGUI currentQuestText;

    public Player player;

    string[] grandPaProcessQuest = new string[] {
        "족장 : 석기는 아직인가?",
        "족장 : 가만있어 보자... 물을 끓여야 되나..."
    };

    string[] grandPaFirstHasQuest = new string[]
    {
        "웅진 : 저기...",
        //                                        "족장 : 음? 뭐야 벌써 깨어난게야?",
        //                                        "웅진 : 저 혹시... 여기가 어딘..",
        //                                        "족장 : 이야~ 일어나는 속도가 장난아닌 거 보니 아주 쓸모있는 녀석이구만 그래!",
        //                                        "웅진 : 저기요 그게...",
        //                                        "족장 : 그래 맞아 내가 숲속에 쓰러져있는 널 데려왔지. 내가 조금만 늦게 나타났으면 벌써 가죽이 벗겨져서 저 나무위에 데롱데롱 매달려있었을 거야!",
        //                                        "웅진 : (헉...!)",
        //                                        "족장 : 허허허 너무 걱정하진 말라고 우리는 쓸모있는 녀석은 안 잡아먹으니까!",
        //                                        "족장 : 음... 그치만 아직 너를 무리에 받아드리긴 너무 일러 아직도 너를 고기로 생각하는 무리들이 있으니까 말이야...",
        //                                        "웅진 : 아아...무리니 뭐니 이런 건 모르겠지만... ",
        //                                        "웅진 : 뭐든 시켜만 주시면 열심히 할게요! 제발 살려주세요!",
        //                                        "족장 : 암 그럼그럼 허나 너를 우리 무리에 들이기엔 증명해야할 것이 있어.",
        //                                        "족장 : 너가 정말 쓸모있는 녀석이란 걸 말이지.",
        //                                        "뽀족하게 깎인 돌맹이를 보여준다.",
        //                                        "족장 : 이것이 무리의 증표다. 아주 멋지지?",
        //                                        "웅진 : (어! 이건 아까 수업시간에 봤던 주먹도끼?... 였나?)",
        //                                        "이번엔 뭉툭하고 한 손에 들어오는 돌맹이를 쥐어준다.",
        //                                        "족장 : 자, 이 돌맹이를 내것 처럼 멋지게 만들어 보렴.",
        //                                        "족장 : 만약 이 돌을 깨트리거나 증표로 쓰기에 부족하다면...",
        //                                        "웅진 : 부족하다면?",
        //                                        "족장 : 불을 피워야겠지?",
        //                                        "웅진 : ...?",
        //                                        "웅진 : ...!",
        //                                        "웅진 : 네 알겠습니다...",
        //                                        "족장은 웅진에게서 시선을 돌린다.",
        //                                        "웅진 : 미치겠네... 만들어 본적도 없는 걸 무슨 수로 만들어!",
        //                                        "웅진 : 하지만...",
        //                                        "웅진 : 고기가 되고 말거야... 만들지 못한다면...",
        //                                        "웅진 : 엄마... 아빠...",
        //                                        "웅진 : 미선아!",
        //                                        "웅진 : 보고싶어... 흑흑...",
        //                                        "웅진 : ... 주먹도끼...",
        //                                        "웅진 : 그래! 학교에서 배운 내용을 더듬어보자.",
                                                "웅진 : 이럴 줄 알았으면 수업시간에 선생님 말씀 좀 들을 걸..."
    };
    string[] grandPaSecondHasQuest = new string[] {
                    "웅진 : 저... 이정도면...",
                    //                            "족장 : 오! 벌써 완성했나?",
                    //                            "족장 : 자네는 뭐든지 빠르구만!",
                    //                            "웅진 : 일단 보여주신거랑 최대한 비슷하게 해봤는데...",
                    //                            "완성된 주먹도끼를 건네준다.",
                    //                            "족장 : 그럼 어디 한 번 볼까?",
                    //                            "웅진 : (두근두근)",
                    //                            "족장 : 흠...",
                    //                            "웅진 : (두근두근)",
                    //                            "족장 : 음...",
                    //                            "웅진 : (표정이 안 좋아보인다...)",
                    //                            "웅진 : (나 이대로 고기가 되는 건가...)",
                    //                            "족장 : 흠냐...",
                    //                            "웅진 : (엄마, 아빠 사랑해요.전 여기까지인가봐요...)",
                    //                            "족장 : 아니! 자네!",
                    //                            "웅진 : (끝이다...)",
                    //                            "족장 : 훌륭한 솜씨구만!무리중에 두 번째로 멋진 주먹도끼야!",
                    //                            "웅진 : 그럼 첫 번째는?",
                    //                            "족장 : 당연히 나지.",
                    //                            "웅진 : 아, 넵.",
                    //                            "족장 : 그보다 자네 내 생각보다 더 쓸모있는 녀석이구만.",
                    //                            "족장 : 이 정도 주먹도끼면 아마 다른 무리원들도 자네를 인정할거야.",
                    //                            "웅진 : 감사합니다.",
                    //                            "족장 : 음... 그래서 말인데",
                    //                            "웅진 : 그래서 말인데?",
                    //                            "족장 : 자네가 우리에게 필요한 석기를 만들어 줬으면 좋겠어.",
                    //                            "족장 : 무리의 일원으로 받아드리겠다는 말이지!",
                    //                            "웅진 : 아, 말씀은 감사합니다. 하지만 저는...",
                    //                            "족장 : 싫은게야?",
                    //                            "웅진 : 아뇨 좋습니다.",
                    //                            "웅진 : (거슬렀다간 고기가 될지 몰라...)",
                    //                            "족장 : 그래 그래 그래야지! 앞으로 자네에게 석기제작을 맡기겠네." ,
                    //                            "족장 : 그런 의미에서 새로운 부탁을 하나 하지.",
                    //                            "웅진 : 어떤 부탁일까요?",
                    //                            "족장 : 사냥한 고기의 가죽을 벗겨야 하는데 이 주먹도끼로는 한계가 있는 것 같아.",
                    //                            "족장 : 뭔가 가죽을 잘 벗길 수 있는 석기가 있으면 손질하기 더 쉬울텐데...",
                    //                            "족장 : 자네가 한 번 만들어 보는 게 어때?",
                    //                            "웅진 : (아마도 긁개를 얘기하는 것 같아.)",
                    //                            "웅진 : (선생님한테 구석기 시대에도 효자손이 있었냐고 장난쳤던 게 기억이 나.)",
                    //                            "웅진 : 네, 맡겨주세요.",
                    //                            "족장에게 다듬어지지 않은 돌은 건네받았다.",
                    //                            "족장 : 아 참, 그럴리 없겠지만 자네가 만약 제작을 하다 돌을 깨뜨렸다면,",
                    //                            "웅진 : 잡아먹나요?",
                    //                            "족장 : 원래대로라면 그렇지. 하지만 다른 얘기를 하려고 했던거야.",
                    //                            "족장 : 저기()쪽에 보이는 덩치 있지? 저녀석이 재료를 모아오는 것을 담당하고 있어.",
                    //                            "족장 : 저 녀석한테 추가 재료를 받을 수 있어.",
                    //                            "웅진 : 아, 감사합니다.",
                    //                            "족장 : 너무 많이 깨뜨리면 잡아먹을거야.",
                    //                            "웅진 : (헙!)",
                                                "족장 : 장난이야 장난! 그럼 어서 가서 석기를 만들어주게!"
    };
    string[] grandPaSecondSuccessQuest = new string[] {
        "족장 : 오! 석기를 완성했나?",
        //                                        "족장 : 음...",
        //                                        "족장 : 오... 날이 아주 날카롭게 선 것을 보니 가죽 벗기기가 쉽겠어!",
        //                                        "족장 : 나무껍질 같은 것도 다듬기에 아주 적당한 모양이야.",
        //                                        "족장 : 그래, 이 석기의 이름은 무엇이지?",
        //                                        "웅진 : 네?! 그니까 저... (뭔가 내가 알려주면 안 될 것 같은데...)",
        //                                        "족장 : 하하! 이 녀석 참, 석기를 만든 사람이 이름도 붙이지 않아서야 되겠나?",
        //                                        "족장 : 이 석기의 용도를 생각해서 이름은 '긁개'로 해야겠어.",
                                                "족장 : 고맙네 자네 덕분이야! 앞으로도 필요한 것이 있으면 부탁하마!"
    };
    string[] grandPaThirdHasQuest = new string[] {
        "웅진 : 무슨 일 있으신가요?",
                                                //"족장 : 음...",
                                                //"웅진 : ...",
                                                //"족장 : ...",
                                                //"웅진 : 저기...",
                                                //"족장 : 오! 자네 마침 잘 왔네!",
                                                //"웅진 : (아... 잘못 걸렸다.)",
                                                //"족장 : 우리는 지금까지 주먹도끼만 있으면 뭐든지 할 수 있다고 생각해 왔어.",
                                                //"족장 : 하지만 냉정하게 생각해 보면 누가 쓰느냐에 따라에 달린 것 같은 석기란 말이지...",
                                                //"족장 : 물론 우리의 증표로 사용되는 물건이기도 하니까 지금에서 다른 물건을 사용한다는 것에 반대하는 무리들도 있다지만...",
                                                //"족장 : 나는 우리에게 새로운 도구가 필요하다고 생각하네.",
                                                //"족장 : 무리들이 받아드리는 건 나중 문제로 치고,",
                                                //"족장 : 자네가 무언가 만들어 줄 수 있나? 주먹도끼보다 훨씬 사용하기 쉬운 석기를 말이야.",
                                                //"웅진 : (수업 시간에 배운 내용을 곰곰이 생각해 보면...)",
                                                //"웅진 : (아마 돌도끼가 등장할 시기겠지?)",
                                                //"웅진 : 네 제가 한 번 해보겠습니다.",
                                                //"웅진 : 대신 몸돌 말고 다른 재료도 필요할 것 같습니다.",
                                                //"족장 : 말해보게.",
                                                //"웅진 : 튼튼한 나뭇가지도 필요합니다.",
                                                //"족장 : 나뭇가지야 널려있는지라 충분히 줄 수 있지.",
                                                //"족장 : 만약 제작에 실패했을 경우에는 알지?",
                                                //"웅진 : 네 알고 있습니다.",
                                                //"웅진 : ...",
                                                //"족장 : ...",
                                                //"웅진 : 잡아먹는 거 아닌 거 맞죠?",
                                                "족장 : ... 글쎄?"
    };
    string[] grandPaThirdSuccessQuest = new string[] {
        "족장 : 오! 이건!",
                                                //"족장 : 나뭇가지와 돌을 이어 붙였구만!",
                                                //"족장 : 참으로 기발한 생각이네. 이것으로 무리원 모두가 사냥과 채집에 있어서 쉽게 할 수 있겠구만!",
                                                "족장 : 역시 내가 사람 보는 눈이 있다니까. 고생했네 고생했어!"
    };
    string[] grandPaForthHasQuest = new string[] {
        "족장 : 오! 자네인가, 마침 잘 왔네.",
                                                //"족장 : 저번에 만들었던 돌도끼 말일세.",
                                                //"족장 : 무리원들의 반응이 아주 좋아!",
                                                //"족장 : 처음에는 낯설고 주먹도끼라는 상징적인 증표 이외에 다른 물건을 사냥에 사용하는 것을 꺼려하는 무리들도 있었지만...",
                                                //"족장 : 결과적으론 대성공이야!",
                                                //"웅진 : 다행이네요.",
                                                //"족장 : 그래서 말인데, 나무에 이어 붙여서 사용할 만한 다른 도구는 없을까?",
                                                //"웅진 : 어... 음...",
                                                //"웅진 : (뭐야? 학교에서 배운 시간대랑 너무 다르잖아! 속도가 너무 빨라!)",
                                                //"웅진 : 힘들 것 같습니다. 아마도요...",
                                                //"족장 : 함... 그렇다면 할 수 없고.",
                                                //"족장 : 이봐, 오늘은 고기 만찬이야. 얼른 물 끓...",
                                                //"웅진 : 하겠습니다.",
                                                "웅진 : (정말로 돌아가고 싶어... 엉엉)"
    };
    string[] grandPaForthSuccessQuest = new string[] {
        "족장 : 거 봐, 할 수 있으면서 엄살은.",
                                                //"웅진 : (여기 온 이후로 숨을 편하게 쉬어 본 적이 없어...)",
                                                //"족장 : 참 신기하단 말이지... 자네가 온 뒤로부터 마을이 점차 발전하는 것 같아.",
                                                //"족장 : 우리는 생각하지도 않았던 방법들이 자네의 머릿속에서 나오는 것도 그렇고.",
                                                //"족장 : 자네는 혹시 신?",
                                                //"웅진 : 그럴 리가요.",
                                                //"족장 : 그렇지?",
                                                //"웅진 : 네.",
                                                //"족장 : 아무튼 이번에도 고맙네. 자네가 만들어준 이 석기로 사냥이나 채집 등 여러 방면에 적용시킬 수 있을 것 같아!",
                                                //"족장 : ...에휴 그러면 뭐해... 요즘따라 무리원들이 아주...",
                                                //"웅진 : 네? 무슨 일 있으신가요?",
                                                "족장 : 아니, 아무것도 아닐세..."
    };
    string[] grandPaFifthHasQuest = new string[] {
        "족장 : 으음...",
                                                //"웅진 : 저기...",
                                                //"족장 : 흠...",
                                                //"웅진 : 저... 할아버지.",
                                                //"족장 : ...",
                                                //"웅진 : 할아버지!!!",
                                                //"족장 : 으잇! 깜짝이야!",
                                                //"족장 : 심장 떨어지게 갑자기 왜 이래!?",
                                                //"웅진 : 할아버지 무슨 생각 하세요?",
                                                //"족장 : 음? 생각은 무슨 생각?",
                                                //"웅진 : 아까부터 한곳만 바라보시고 한숨만 쉬시잖아요.",
                                                //"족장 : 아, 음... 그게 말이다...",
                                                //"족장 : 에휴, 사실은...",
                                                //"족장 : 저 골짜기가 보이느냐? 항상 무리의 남자들이 사냥을 하러 나서는 길이지.",
                                                //"족장 : 한때 여기에 앉아서 드나드는 무리원들을 보면 뿌듯해하고 기분 좋게 하루를 시작하곤 했지.",
                                                //"족장 : 가끔 다쳐서 오는 친구들을 보면 걱정도 됐지만 꼭 그들은 우리가 먹을 것을 가지고 당당하게 들어섰어.",
                                                //"족장 : 그런데 요즘 들어 부쩍 다치는 친구들이 늘었고, 빈손으로 오는 경우도 허다해...",
                                                //"족장 : 먹을 것을 구하는 것도 당연히 중요하지. 중요하다만...",
                                                //"족장 : 무리의 젊은이들이 자꾸 그렇게 다쳐나가면 앞으로는 어떻게 할지...",
                                                //"족장 : 요즘 들어 자꾸 이런 생각들이 드니까 나도 모르게 여기 앉아서 한숨만 쉬고는 있는 걸세...",
                                                //"웅진 : (요새 부쩍 기운이 없어진 모습을 보이신 이유가 있으셨구나...)",
                                                //"웅진 : (내가 할 수 있는 일이 없을까?)",
                                                //"웅진 : (아, 맞다! 분명 교과서가 있었을 텐데!)",
                                                "웅진 : (과연 우가가 순순히 건네줄지가 문제다만...)"
    };
    string[] grandPaFifthSuccessQuest = new string[] {
        "웅진 : 할아버지!!!",
                                                //"족장 : 아잇, 깜짝이야!",
                                                //"족장 : 갑자기 소리 지르지 말라니까 말이야!",
                                                //"웅진 : 이것 좀 보세요!",
                                                //"족장 : 으잉?",
                                                //"날카롭게 날이 선 돌화살촉을 보여준다.",
                                                //"족장 : 호오... 날이 아주 날카롭구나.",
                                                //"웅진 : 이게 끝이 아니에요.",
                                                //"곧게 뻗은 나뭇가지 머리에 이어 붙인 후 두껍고 질긴 다른 나뭇가지에 끈을 연결하여 보여준다.",
                                                //"족장 : 이게 뭐고?",
                                                //"웅진은 활과 돌화살촉을 이용하여 화살이 날아가는 모습을 족장 앞에 선보인다.",
                                                //"족장 : 오오호... 정말이지...",
                                                //"웅진 : 할아버지 이건 말이...",
                                                //"족장 : 알지 알지... 잘 알고 말고!",
                                                //"웅진 : 그게 이제 뭐냐면...",
                                                //"족장 : 그래! 자네, 이 새로운 사냥도구를 어서 다른 이들에게 알려주게나!",
                                                //"웅진 : (아니, 사냥도구인 건 또 어떻게 아셨대?)",
                                                //"웅진 : (그나저나 얼굴이 조금 펴지신 것 같아서 다행이네.)",
                                                "웅진 : 네, 할아버지!"
    };
    string[] grandPaSixthHasQuest = new string[] {
        "족장 : 오, 자네 왔는가?",
                                                //"웅진 : 요즘 다들 바쁘신가봐요? 우가씨도 열심히 하시고.",
                                                //"족장 : 음, 그럼 그럼. 이젠 우리가 먹이를 찾으러 여기저기 돌아다니지 않아도 될 지경이라니까.",
                                                //"웅진 : 확실히 부족함을 느끼고 있지는 않았아요.",
                                                //"웅진 : 제 새로운 사냥도구 덕분인가요?",
                                                //"족장 : 하하하! 그 말도 맞지!",
                                                //"족장 : 자, 마침 사냥을 마치고 돌아오고있어!",
                                                //"저 멀리 산 골짜기에서 사냥감을 어깨에 걸치고 돌아오는 다수의 무리들이 포효를 하듯 함성을 외치며 마을로 돌아온다.",
                                                //"족장 : 저 골짜기에서 들려오는 함성소리도 전으로 돌아온 것 같아 기분이 좋아.",
                                                //"족장 : 그뿐만이 아니야, 이번 정착지는 신기한 점이 하나 있어.",
                                                //"웅진 : 어떤 거죠?",
                                                //"족장 : 저 앞에 특별히 어두컴컴한 땅이 보이나?",
                                                //"웅진 : 네.",
                                                //"족장 : 저 땅에서 보리가 처음 자랄 때 싹이 보이기 시작했어.",
                                                //"웅진 : 네?",
                                                //"족장 : 보통 정착지를 이동할 때 저 싹들을 보고 움직이며 다음 정착지를 정하곤 했지.",
                                                //"족장 : 헌데 아직 먹을 것이 많이 있는 자리에서 새싹까지 난다면...",
                                                //"웅진 : 난다면?",
                                                //"족장 : 우리는 위험을 무릅쓰고 정착지를 옮길 필요가 없다는 말이야.",
                                                //"족장 : 그래서 저 땅 옆에서 저렇게 비를 피할 곳까지 마련하면서 지켜보고 있는 게야.",
                                                //"족장 : 그리고 우리는 잔돌이라던가 다른 풀들이 없이 고른 땅에서 잘 자란다는 것을 선조들께서 알려주셨지.",
                                                //"족장 : 저 땅을 고르게 할 수 있는 방법이 뭐가 없을까?",
                                                //"웅진 : 그러게요.",
                                                //"웅진 : 저한테 하신 말씀이세요?",
                                                //"족장 : 이젠 무리에서의 자네의 위치를 누구보다 잘 알지 않나?",
                                                //"웅진 : 그러네요.",
                                                "웅진 : (킹받네...)"
    };
    string[] grandPaSixthSuccessQuest = new string[] {
        "족장 : 흠... 좋아.",
                                                //"웅진 : 너무 당연하다는 듯 칭찬마저 없으시네요.",
                                                //"족장 : 마을을 위한 일인데 마음자리가 곱지 못하군.",
                                                "웅진 : 이젠 억지마저 익숙합니다."
    };


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        talkData = new Dictionary<int, QuestDataStruct>();
        GenerateData();
        nextButton.onClick.AddListener(() => NextTalk());
        outButton.onClick.AddListener(() => OutTalk());
    }


    void GenerateData()
    {

        // 인물NPC 대사
        // 족장
        QuestDataStruct grandPaProcessQuestData;
        grandPaProcessQuestData.questArr = grandPaProcessQuest;
        grandPaProcessQuestData.hasSuccessComment = false;

        talkData.Add(1000, grandPaProcessQuestData);

        // 우가
        //talkData.Add(2000, new string[] { "날씨가 좋군" });

        ////몰?루
        //talkData.Add(3000, new string[] { "열매 채집을 해야겠어!" });

        //// 동물NPC 대사
        //// 곰탱이
        //talkData.Add(100, new string[] { "크아앙!",
        //                                 "...",
        //                                 "다음부터는 놀래는 척이라도 해달라곰."});

        //// 개구락지
        //talkData.Add(200, new string[] { "개굴, 개굴",
        //                                 "혹시 너, 금으로 만든 공을 가져다주지 않으련?",
        //                                 "아, 여기가 아닌가"});

        ////토깽이
        //talkData.Add(300, new string[] { "깊은 산 속",
        //                                 "옹~달~샘~",
        //                                 "네가 다 마셨냐?"});

        ////고라니사촌
        //talkData.Add(400, new string[] { "으악!",
        //                                 "내 뿔 멋있지 않니?",
        //                                 "아아, 먹는 건 아니니까 건드리지는 마"});

        ////개
        //talkData.Add(500, new string[] { "워우~~~",
        //                                 "...",
        //                                 "그냥 습관적으로 나오니까 무시해줘."});

        // Quest Talk(0 : 퀘스트를 보유중일때, 1 : 퀘스트 완료시, 2 : 퀘스트 진행 중일때)
        // 퀘스트 번호 + NPC Id
        QuestDataStruct grandPaFirstHasQuestData;
        grandPaFirstHasQuestData.questArr = grandPaFirstHasQuest;
        grandPaFirstHasQuestData.hasSuccessComment = false;

        talkData.Add(1010, grandPaFirstHasQuestData);

        QuestDataStruct grandPaSecondHasQuestData;
        grandPaSecondHasQuestData.questArr = grandPaSecondHasQuest;
        grandPaSecondHasQuestData.hasSuccessComment = true;

        talkData.Add(1020, grandPaSecondHasQuestData);

        QuestDataStruct grandPaSecondSuccessQuestData;
        grandPaSecondSuccessQuestData.questArr = grandPaSecondSuccessQuest;
        grandPaSecondSuccessQuestData.hasSuccessComment = false;

        talkData.Add(1021, grandPaSecondSuccessQuestData);

        QuestDataStruct grandPaThridHasQuestData;
        grandPaThridHasQuestData.questArr = grandPaThirdHasQuest;
        grandPaThridHasQuestData.hasSuccessComment = true;

        talkData.Add(1030, grandPaThridHasQuestData);

        QuestDataStruct grandPaThridSuccessQuestData;
        grandPaThridSuccessQuestData.questArr = grandPaThirdSuccessQuest;
        grandPaThridSuccessQuestData.hasSuccessComment = false;

        talkData.Add(1031, grandPaThridSuccessQuestData);

        QuestDataStruct grandPaForthHasQuestData;
        grandPaForthHasQuestData.questArr = grandPaForthHasQuest;
        grandPaForthHasQuestData.hasSuccessComment = true;

        talkData.Add(1040, grandPaForthHasQuestData);

        QuestDataStruct grandPaForthSuccessQuestData;
        grandPaForthSuccessQuestData.questArr = grandPaForthSuccessQuest;
        grandPaForthSuccessQuestData.hasSuccessComment = true;

        talkData.Add(1041, grandPaForthSuccessQuestData);

        QuestDataStruct grandPaFifthHasQuestData;
        grandPaFifthHasQuestData.questArr = grandPaFifthHasQuest;
        grandPaFifthHasQuestData.hasSuccessComment = true;

        talkData.Add(1050, grandPaFifthHasQuestData);

        //talkData.Add(51 + 2000, new string[] { "웅진 : 우가!",
        //                                        "우가 : 응? 무슨 일이냐우가?",
        //                                        "웅진 : 책!",
        //                                        "우가 : 어허, 책은 우가가 가지기로 하지 않았냐 우가!",
        //                                        "웅진 : 대체 언제 그런 약속을 했죠?",
        //                                        "우가 : 크흠...",
        //                                        "웅진 : 나 지금 우가가 가지고 있는 책들 중 필요한 게 있어요.",
        //                                        "우가 : 음? 그게 우가랑 무슨 상관이 있나우가?",
        //                                        "웅진 : 음...",
        //                                        "우가 : 음?",
        //                                        "웅진 : 우가도 친구들이 다치는 건 싫지 않나요?",
        //                                        "우가 : 우가의 친구들?",
        //                                        "웅진 : 네, 요즘 사냥 나가서 다들 다치고 돌아온다면서요...",
        //                                        "우가 : ...",
        //                                        "웅진 : !?",
        //                                        "우가는 한참을 침묵한 후 힘겹게 입을 열었다.",
        //                                        "우가 : 우가는 좋다.",
        //                                        "웅진 : 뭐가요?",
        //                                        "우가 : 저 산에서 들려오는 새들의 노랫소리...",
        //                                        "우가 : 나무 끝에서 들려오는 춤추는 바람의 소리...",
        //                                        "우가 : 그중에서 우가가 가장 좋아하는 소리는...",
        //                                        "우가 : 저 산골짜기에서 들려오는 사냥감을 들쳐업고 나타난 동료들의 함성소리다.",
        //                                        "우가 : ... 언제부터인가 저 흥겨운 소리가 당연한 것이 아닐지도 모른다는 생각이 든다.",
        //                                        "우가 : ... 이게 필요하다 했나우가?",
        //                                        "우가 : 자, 언제나 그렇듯 우가에게 설명할 것이 있나우가?",
        //                                        "우가는 책들을 힘 없이 건넨 후, 그 무엇도 기대하지 않는 눈빛으로 시선을 하늘로 올릴 뿐이다.",
        //                                        "웅진 : (분명 석기시대에 대한 내용이 있을 거야!)",
        //                                        "(뒤적뒤적)",
        //                                        "(뒤적뒤적)",
        //                                        "웅진 : 무슨 죄다 만화책이야...",
        //                                        "웅진 : 어?",
        //                                        "3-2 사회 교과서가 낱장이 뜯어져 있고, 흙먼지가 덕지덕지 붙어있는 채로 발견됐다.",
        //                                        "웅진 : 아... 이를 어째...",
        //                                        "흩어진 낱장을 모아 맞추자 조금씩 글자가 갖춰지기 시작했다.",
        //                                        "웅진 : 간석... 기?",
        //                                        "웅진 : ... 그리고...",});

        QuestDataStruct grandPaFifthSuccessQuestData;
        grandPaFifthSuccessQuestData.questArr = grandPaFifthSuccessQuest;
        grandPaFifthSuccessQuestData.hasSuccessComment = true;

        talkData.Add(1051, grandPaFifthSuccessQuestData);

        QuestDataStruct grandPaSixthHasQuestData;
        grandPaSixthHasQuestData.questArr = grandPaSixthHasQuest;
        grandPaSixthHasQuestData.hasSuccessComment = true;

        talkData.Add(1060, grandPaSixthHasQuestData);

        QuestDataStruct grandPaSixthSuccessQuestData;
        grandPaSixthSuccessQuestData.questArr = grandPaSixthSuccessQuest;
        grandPaSixthSuccessQuestData.hasSuccessComment = true;

        talkData.Add(1061, grandPaSixthSuccessQuestData);

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

        // 마지막 대화에서 다음 버튼 안 보이게
        if (talkIndex == talkData[id].questArr.Length - 1)
            nextButton.gameObject.SetActive(false);
        else
            nextButton.gameObject.SetActive(true);


        if (talkIndex == talkData[id].questArr.Length)
            return null;
        else
            return talkData[id].questArr[talkIndex];
    }

    public bool GetHasSuccessComment(int id)
    {
        return talkData[id].hasSuccessComment;
    }

    void NextTalk()
    {
        manager.Action(player.GetScanObject());
    }

    void OutTalk()
    {
        ObjData npcObj;

        talkPanel.SetActive(false);
        npcObj = player.GetScanObject().GetComponent<ObjData>();

        if (npcObj.GetNPCQuestState() == NPCQuestState.HAVE_QUEST)
        {
            player.SetCurrentQuest(npcObj);
            npcObj.SetProcessingPlayer(player);

            currentQuestText.text = npcObj.GetQuestTitle(npcObj.GetCurrentQuest());
            npcObj.SetNPCQuestState(NPCQuestState.PROCESS_QUEST);
        }
        else if(npcObj.GetNPCQuestState() == NPCQuestState.SUCCESS_QUEST)
        {
            npcObj.IncreaseCurrentQuest();
            npcObj.SetNPCQuestState(NPCQuestState.HAVE_QUEST);
        }
        manager.talkIndex = 0;
    }

}
