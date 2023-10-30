using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public GameObject joyStick;
    public GameObject dialog;
    public GameObject npcCamera;

    public Text npcDialogue; // NPC의 대화를 출력할 텍스트

    public TalkManager talkManager;

    // NPC의 대화 내용
    string[] dialogues;
    int index = 0;
    bool isTyping = false; // 대사 출력이 진행 중인지를 판단하는 변수

    void Awake()
    {
        dialogues = new string[]
        {
            "　　　　　　　　　",
            "안녕하세요!",
            "오늘 날씨가 좋네요.",
            "즐거운 하루 되세요."
        };
    }

    void OnEnable()
    {
        if (index < dialogues.Length)
        {
            StartCoroutine(TypeSentence(dialogues[index]));
        }
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭을 감지하면 다음 대화 시작
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            if (index < dialogues.Length)
            {
                StartCoroutine(TypeSentence(dialogues[index]));
            }
            else
            {
                joyStick.gameObject.SetActive(true);
                dialog.gameObject.SetActive(false);
                npcCamera.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        npcDialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            npcDialogue.text += letter;
            yield return new WaitForSeconds(0.1f); // 각 글자 출력 간의 시간 간격
        }
        isTyping = false;

        // 대사 출력이 끝난 후에 인덱스 증가
        if (index < dialogues.Length)
        {
            index++;
        }
    }

}
