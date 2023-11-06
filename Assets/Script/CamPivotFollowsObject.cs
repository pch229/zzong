using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPivotFollowsObject : MonoBehaviour
{
    public Transform following_object;//무엇을 카메라가 따라갈건지 변수로 선언해줌
    public FixedJoystick joystick;//조이스틱 변수 
    public float cameraSpeed;// 조이스틱을 움직여서 카메라를 회전시킬 때 어느정도의 스피드로 할 것인지 설정.
    private float totalRotation = 0f;// 카메라 회전의 누적값
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
           
            //카메라 회전 관련 수식, y축 기준으로 회전했을 때 제외하고는 모두 음수의 값으로 회전 하지 않도록 설정.
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
