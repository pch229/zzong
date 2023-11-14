using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float movementX;
    public float movementY;

    void Update()
    {
        movementX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        movementY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Vector3 stagePosition = target.transform.position;

        transform.RotateAround(stagePosition, Vector3.right, -movementY);
        transform.RotateAround(stagePosition, Vector3.up, movementX);

        transform.LookAt(stagePosition);
    }

    void FixedUpdate()
    {
        //Vector3 moveVec = new Vector3(0, movementX, 0);
        //float speed = Time.deltaTime * moveSpeed;
        
        //transform.RotateAround(target.position, moveVec, speed);

        //Quaternion targetRotation = transform.rotation;
        //targetRotation.x += movementY * Time.deltaTime * moveSpeed;

        //transform.rotation = targetRotation;
    }

    private void OnMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
    }
}
