using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float fastPower = 5f;
    [SerializeField] float perfectPower = 0.5f;

    Rigidbody rb;
    StoneControl stoneControl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stoneControl = FindAnyObjectByType<StoneControl>();
    }
    void Update()
    {
        Transform transform = gameObject.transform;
        float y = (Time.deltaTime * moveSpeed) * -1;
        transform.Translate(0, y, 0);

        Debug.Log(stoneControl.GetCurrentSpeed());

        AddForceToGauge();

        if (transform.position.y > 0.2f)
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        else if (transform.position.y < -0.2f)
            transform.position = new Vector3(transform.position.x, -0.2f, transform.position.z);
    }

    void AddForceToGauge()
    {
        if (stoneControl.GetCurrentSpeed() == GrindingSpeed.fast)
        {
            rb.AddForce(Vector3.up * fastPower);
        }
        else if (stoneControl.GetCurrentSpeed() == GrindingSpeed.slow)
        {
            rb.AddForce(Vector3.up * 0f);
        }
        else if (stoneControl.GetCurrentSpeed() == GrindingSpeed.perfect)
        {
            rb.AddForce(Vector3.up * perfectPower);
        }
    }
}
