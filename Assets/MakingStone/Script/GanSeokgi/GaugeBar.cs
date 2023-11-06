using System.Collections;
using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    [SerializeField] float gaugePower = 5f;

    Rigidbody rb;
    RectTransform arrowTransform;
    Coroutine successCoroutine = null;
    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        arrowTransform = GetComponent<RectTransform>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (arrowTransform.anchoredPosition.y < -290)
        {
            arrowTransform.anchoredPosition = new Vector2(arrowTransform.anchoredPosition.x, -290);
            rb.velocity = new Vector3(0, 0);
        }
        else if (arrowTransform.anchoredPosition.y > -47)
        {
            arrowTransform.anchoredPosition = new Vector2(arrowTransform.anchoredPosition.x, -47);
            rb.velocity = new Vector3(0, 0);
            gameManager.SetGameResult(GameState.fail);
        }

        if (arrowTransform.anchoredPosition.y < -115 && arrowTransform.anchoredPosition.y > -190)
        {
            if (successCoroutine == null)
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
            gameManager.SetSuccessRate();
            gameManager.SetGameResult(GameState.success);
        }
    }

    public void AddForceToGauge()
    {
        rb.AddForce(Vector3.up * gaugePower);
    }
}
