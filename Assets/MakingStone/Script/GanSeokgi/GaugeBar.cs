using System.Collections;
using UnityEngine;

public class GaugeBar : MonoBehaviour
{
    [SerializeField] float gaugePower = 30f;

    Rigidbody2D rb2D;
    Coroutine successCoroutine = null;
    GameManager gameManager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    IEnumerator SuccessCount()
    {
        yield return new WaitForSeconds(7f);
        if (successCoroutine != null)
        {
            gameManager.SetSuccessRate();
            gameManager.SetGameResult(GameState.success);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.name == "Gauge Low Point")
        {
            rb2D.gravityScale = 0f;
            rb2D.velocity = new Vector2(0, 0);
        }
        else if (collision.gameObject.transform.name == "Gauge High Point")
        {
            gameManager.SetGameResult(GameState.fail);
            rb2D.velocity = new Vector2(0, 0);
        }
        else if (collision.gameObject.transform.name == "Gauge Success Point")
        {
            if (successCoroutine == null)
            {
                successCoroutine = StartCoroutine(SuccessCount());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.name == "Gauge Low Point")
        {
            rb2D.gravityScale = 1f;
        }
        else if (collision.gameObject.transform.name == "Gauge Success Point")
        {
            successCoroutine = null;
        }
    }

    public void AddForceToGauge()
    {
        rb2D.AddForce(Vector3.up * gaugePower);
    }
}
