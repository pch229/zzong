using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform following_object;
    public FixedJoystick joystick;
    public float cameraSpeed;
    private float totalRotation = 0f;
    public GameObject inventory;
   

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "inven")
        {
            //inventory.gameObject.SetActive(true);
            
            joystick.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {

        Vector3 pos = this.transform.position;
        this.transform.position = Vector3.Lerp(pos, following_object.position, 0.4f);

        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if(horizontalInput != 0 || verticalInput != 0)
        {
           
                float yrotationAngle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
                float zrotationAngle = Mathf.Max(0, Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg);
                float xrotationAngle = Mathf.Max(0, Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg);
                Quaternion targetRotation = Quaternion.Euler(xrotationAngle, yrotationAngle, zrotationAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSpeed * Time.fixedDeltaTime);
            totalRotation += xrotationAngle;
            totalRotation += zrotationAngle;
            
        }
        
    }
}
