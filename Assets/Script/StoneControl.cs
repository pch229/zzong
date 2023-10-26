using UnityEngine;

public class StoneControl : MonoBehaviour
{
    [SerializeField] float fastGrindingVal = 10f;
    [SerializeField] float slowGrindingVal = 2.5f;

    ParticleSystem grindingParticle;

    bool isClicked = false;
    Vector3 mousePosition;

    void Start()
    {
        grindingParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(isClicked)
        {
            ProcessGrinding();
        }
    }

    void ProcessGrinding()
    {
        RaycastHit hit;
        ParticleSystem.EmissionModule emissionModule = grindingParticle.emission;
        float mouseDiffX;
        float mouseDiffY;

        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, 1000))
        {
            if (hit.transform.gameObject.name == "Tool_Grinding_Plate")
            {
                mouseDiffX = Mathf.Abs(mousePosition.x - Input.mousePosition.x);
                mouseDiffY = Mathf.Abs(mousePosition.y - Input.mousePosition.y);
                emissionModule.enabled = true;
                mousePosition = Input.mousePosition;

                if(mouseDiffX > fastGrindingVal || mouseDiffY > fastGrindingVal)
                {
                    Debug.Log("fast");
                }
                else if(mouseDiffX < slowGrindingVal || mouseDiffY < slowGrindingVal)
                {
                    Debug.Log("slow");
                }
                else
                {
                    Debug.Log("Perfect");
                }
            }
        }
        else
        {
            emissionModule.enabled = false;
        }
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
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objPos;
    }
}
