using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Gamemanager manager;
    public GameObject scanObject;
    public Button talkButton;


    public FixedJoystick joy;
    public float speed;
    private bool isWalking = false;
    private bool isIdle = false;
    public GameObject inventory;
    public GameObject Canvas;
    public Button makebutton;
    public Button jumpbutton;
    public float jumpPower = 3f;
    public Gamemanager gameManager;
    bool isJumping = false;
    //public Button jumpbutton;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    public void Onclick()
    {
        if (!isJumping)
        {
            anim.SetTrigger("isJump");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inven"))
        {
            inventory.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
            isWalking = false;
            isIdle = true;
            // StopMovement();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("inven"))
        {
            isWalking = true;
            isIdle = false;
        }
    }
    public void makeClose()
    {
        inventory.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(true);
        isWalking = true;
        isIdle = true;
    }

    void TalkStart()
    {
        if (scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void Awake()
    {
        talkButton.onClick.AddListener(() => TalkStart());

        rigid = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        // 1. Input Value
        float x = joy.Horizontal;
        float z = joy.Vertical;

        // 2. Move Position 
        moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        if (moveVec.sqrMagnitude == 0)
            return; // #. No input = No Rotation

        // 3. Move Rotation
        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
        rigid.MoveRotation(moveQuat);

        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, 0.7f))
        {
            Debug.Log(scanObject);
            if (rayHit.collider.tag == "NPC")
            {
                scanObject = rayHit.collider.gameObject;
                talkButton.gameObject.SetActive(true);
            }
            else scanObject = null;
        }

    }

    void LateUpdate()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isIdle", isIdle);
    }
    void StopMovement()
    {
        rigid.velocity = Vector3.zero;
        speed = 0;
    }

    public GameObject GetScanObject()
    {
        return scanObject;
    }
}


