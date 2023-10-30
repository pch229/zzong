using System.Collections;
using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float fastPower = 5f;
    [SerializeField] float perfectPower = 0.5f;

    Rigidbody rb;
    StoneControl stoneControl;
    RectTransform arrowTransform;
    Coroutine successCoroutine = null;
    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stoneControl = FindAnyObjectByType<StoneControl>();
        arrowTransform = GetComponent<RectTransform>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        AddForceToGauge();

        if (arrowTransform.anchoredPosition.y < -290)
        {
            arrowTransform.anchoredPosition = new Vector2(arrowTransform.anchoredPosition.x, -290);
            rb.velocity = new Vector3(0, 0);
        } 
        else if (arrowTransform.anchoredPosition.y > -47)
        {
            arrowTransform.anchoredPosition = new Vector2(arrowTransform.anchoredPosition.x, -47);
            rb.velocity = new Vector3(0, 0);
        }
        
        if (arrowTransform.anchoredPosition.y < -115 && arrowTransform.anchoredPosition.y > -190)
        {
            if(successCoroutine == null)
            {
                successCoroutine = StartCoroutine(SuccessCount());
            }
        }
        else
        {
            successCoroutine = null;
        }
    }

    IEnumerator SuccessCount()
    {
        yield return new WaitForSeconds(5f);
        if (arrowTransform.anchoredPosition.y < -115 && arrowTransform.anchoredPosition.y > -190)
        {
            gameManager.SetGameResult(true);
        }
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
