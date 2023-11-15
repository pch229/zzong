using OpenCover.Framework.Model;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform cameraArm;
    [SerializeField] private float speed = 5f;

    Animator animator;
    Rigidbody rigid;
    bool isPickup;
    bool isMove;
    public float jumpPower = 3f;
    public GameObject joyStick;
    AnimatorStateInfo animatorState;
    public PlayerJoystick playerJoystick;


    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        isPickup = false;
    }

    void Update()
    {
        animatorState = animator.GetCurrentAnimatorStateInfo(0);

        if (isPickup)
        {
            animator.SetTrigger("isPickUp");
            isPickup = false;
        }

        if (animatorState.IsName("Picking Up"))
        {
            joyStick.SetActive(false);
        }
        else
        {
            playerJoystick.ResetLeverPosition();
            joyStick.SetActive(true);
            isMove = false;

            if (!isMove && !isPickup)
            {
                animator.SetBool("isIdle", true);
            }
            else
            {
                animator.SetBool("isIdle", false);
            }
        }
    }

    public void Move(Vector3 moveVector)
    {
        // Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // bool isMove = moveInput.magnitude != 0;
        
        isMove = moveVector.magnitude != 0;

        if (isMove)
        {

            animator.SetBool("isMove", true);
            animator.SetBool("isIdle", false); 
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            // Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            Vector3 moveDir = lookForward * moveVector.y + lookRight * moveVector.x;

            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * speed;
        }
        else
        {
            animator.SetBool("isMove", false); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Branch")
        {
            isPickup = true;
        }
    }

    public void LookAround(Vector3 moveVector)
    {
        // Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        // float x = camAngle.x - mouseDelta.y;
        float x = camAngle.x - moveVector.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        // cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + moveVector.x, camAngle.z);
    }

    public void Onclick()
    {
        animator.SetTrigger("isJump");
        animator.SetBool("isIdle", false); 
        rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
