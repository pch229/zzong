using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player_keyboard : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public GameManager manager;
    public GameObject scanObject;
    public Button talkButton;

    float distance;
    public float withNPCDistance;
    GameObject NPC;

    private void Start()
    {
        NPC = GameObject.FindGameObjectWithTag("NPC");
    }
    void Awake()
    {
        talkButton.onClick.AddListener(() => TalkStart());
    }

    void TalkStart()
    {
        if (scanObject != null)
        {
            manager.Action(scanObject);
        }
    }
    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
        {
            manager.Action(scanObject);
            Debug.Log("manager.Action");
        }
        
        // �Ÿ� üũ �̿ϼ��̶� �ϼ����ּ���
        /*distance = Vector3.Distance(NPC.transform.position, transform.position);

        if (distance <= withNPCDistance)
        {
            scanObject = .collider.gameObject;
            talkButton.gameObject.SetActive(true);
        }*/
    }
    

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
        RaycastHit rayHit; 
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, 0.7f))
        {
            if (rayHit.collider.tag == "NPC")
            {
                scanObject = rayHit.collider.gameObject;
                talkButton.gameObject.SetActive(true);
            } 
            else scanObject = null;
        }
        
    }
}
