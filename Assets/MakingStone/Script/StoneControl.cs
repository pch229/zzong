using UnityEngine;

public enum GrindingSpeed
{
    fast,
    slow,
    perfect,
    none
}

public class StoneControl : MonoBehaviour
{
    ParticleSystem grindingParticle;
    GameManager gameManager;
    GaugeBar gaugeBar;

    bool isClicked = false;
    Vector3 mousePosition;
    GrindingSpeed currentSpeed = GrindingSpeed.none;

    void Start()
    {
        grindingParticle = GetComponentInChildren<ParticleSystem>();
        gameManager = FindObjectOfType<GameManager>();
        gaugeBar = FindObjectOfType<GaugeBar>();
    }

    void Update()
    {
        if (isClicked) // 돌이 클릭되면
        {
            if (gameManager.GetGameResult() == GameState.none)
            {
                ProcessGrinding();
            }
        }
        else
        {
            currentSpeed = GrindingSpeed.none;
        }
    }

    void ProcessGrinding()
    {
        RaycastHit hit;
        var emissionModule = grindingParticle.emission;

        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, 1000)) // 돌에서 z축으로 레이저 발사
        {
            if (hit.transform.gameObject.name == "Tool_Grinding_Plate") // 돌이 판 위에 있을경우에만
            {
                Vector3 mouseDiff = GetMouseDiff();

                emissionModule.enabled = true;
                mousePosition = Input.mousePosition;

                DetectGrindingSpeed(mouseDiff); // 가는 속도 판별
            }
        }
        else
        {
            emissionModule.enabled = false;
            currentSpeed = GrindingSpeed.none;
            return;
        }
    }

    public GrindingSpeed GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void DetectGrindingSpeed(Vector3 mouseDiff)
    {
        if (mouseDiff.x > 0 || mouseDiff.y > 0)
        {
            gaugeBar.AddForceToGauge();
        }
    }

    Vector3 GetMouseDiff()
    {
        float mouseDiffX;
        float mouseDiffY;

        mouseDiffX = Mathf.Abs(mousePosition.x - Input.mousePosition.x);
        mouseDiffY = Mathf.Abs(mousePosition.y - Input.mousePosition.y);

        return new Vector3(mouseDiffX, mouseDiffY, 0);
    }

    void OnMouseDown()
    {
        isClicked = true;
        mousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isClicked = false;
    }

    void OnMouseDrag()
    {
        if (gameManager.GetGameResult() == GameState.none)
        {
            float distance = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = objPos;
        }
    }
}
