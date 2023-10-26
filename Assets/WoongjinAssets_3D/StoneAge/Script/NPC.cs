using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Transform player;
    float distance;
    public float withPlayerDistance;
    public GameObject talkButton;
    public GameObject joyStick;
    public GameObject dialog;
    public GameObject npcCamera;

    bool isTalk;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isTalk = false;
    }

    void Update()
    {
        // 플레이어와 npc 사이 거리 체크
        distance = Vector3.Distance(player.transform.position, transform.position);

        // 플레이어와 npc 사이 거리가 특정 거리 안으로 들어가면 대화하기 버튼 활성화
        if (distance <= withPlayerDistance && !isTalk)
        {
            talkButton.gameObject.SetActive(true);
        }
        else talkButton.gameObject.SetActive(false);
    }
    public void Onclick()
    {
        joyStick.gameObject.SetActive(false);
        dialog.gameObject.SetActive(true);
        // npc 전용 뷰로 이동
        npcCamera.gameObject.SetActive(true);
        talkButton.gameObject.SetActive(false);

        isTalk = true;
    }
}
