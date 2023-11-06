using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public FixedJoystick joy;
    public float speed;
    private bool isWalking = false;
    private bool isIdle = false;
    public GameObject inventory;
    public GameObject Canvas;
    public Button makebutton;
    public GameObject Background;
    public Button jumpbutton;
    public float jumpPower = 3f;
    bool isJumping = false;
    //public Button jumpbutton;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;
    //Vector3 camVec;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    public void Onclick()
    {
        if(!isJumping)
        {
            anim.SetTrigger("isJump");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("inven"))
        {
            inventory.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
            isWalking = false;
            isIdle = true;
            StopMovement();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("inven"))
        {
            isWalking = true; 
            isIdle = false;
        }
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // 1. Input Value
        float x = joy.Horizontal;
        float z = joy.Vertical;

        // 2. Move Position 
        moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);


        if (moveVec.sqrMagnitude == 0) { 
            isWalking = false;
           isIdle = true;
            //StopMovement();
            // #. No input = No Rotation
        }
        else
        {
            isWalking = true;
            isIdle = false;
        }
        if (isWalking)
        {
            // 3. Move Rotation
            Quaternion dirQuat = Quaternion.LookRotation(moveVec);
            Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.3f);
            rigid.MoveRotation(moveQuat);
        }
    }
    void LateUpdate()
    {
        anim.SetBool("isWalking",isWalking);
        anim.SetBool("isIdle", isIdle);
    }
    void StopMovement()
    {
        rigid.velocity = Vector3.zero;
        speed = 0;
    }
    public void makeclick()
    {
        Background.gameObject.SetActive(true);
    }
}


