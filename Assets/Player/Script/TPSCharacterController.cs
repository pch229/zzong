using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform cameraArm;
    [SerializeField] private float speed = 5f;

    Animator animator;

    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    void Update()
    {
        // LookAround();
        // Move();
    }

    public void Move(Vector3 moveVector)
    {
        // Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // bool isMove = moveInput.magnitude != 0;

        bool isMove = moveVector.magnitude != 0;
        animator.SetBool("isMove", isMove);

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            // Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            Vector3 moveDir = lookForward * moveVector.y + lookRight * moveVector.x;

            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * speed;
        }
        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized, Color.red);
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
}
