using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameManager manager;

    public GameObject talkButton;
    GameObject scanObject;
    RaycastHit hit;
    /*public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        Vector3 moveDistance = PlayerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
    private void Rotate()
    {
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        playerRigidbody.rotation * Quaternion.Euler(0, turn, 0);    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
    public FixedJoystick joy;
    public float speed;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
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
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "NPC")
            {
                scanObject = hit.collider.gameObject;
            }
        }
        if (scanObject != null)
        {
            talkButton.gameObject.SetActive(true);
        }

    }

    void LateUpdate()
    {
        //anim.SetFloat("Move", moveVec.sqrMagnitude);
    }

    public void Onclick()
    {
        manager.Action(scanObject);
        //talkButton.gameObject.SetActive(false);
    }
}


