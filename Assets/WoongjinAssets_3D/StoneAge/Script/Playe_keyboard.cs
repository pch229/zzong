using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Playe_keyboard : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    RaycastHit hit;

    public GameManager manager;

    public GameObject talkButton;
    GameObject scanObject;
    public bool isTalk = false;

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) && scanObject != null)
        {
            manager.Action(scanObject);
        }
        
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
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "NPC")
            {
                scanObject = hit.collider.gameObject;
                talkButton.gameObject.SetActive(true);
            } 
            else scanObject = null;
        }
    }
    /*
    public void Onclick()
    {
        isTalk = true;
    }
    */
}
