using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class StoneControl : MonoBehaviour
{
    ParticleSystem grindingParticle;

    bool isClicked = false;

    void Start()
    {
        grindingParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if(isClicked)
        {
            RaycastHit hit;
            ParticleSystem.EmissionModule emissionModule = grindingParticle.emission;

            Debug.DrawRay(gameObject.transform.position + new Vector3(0, 0, 0.25f), Vector3.forward, UnityEngine.Color.red);

            if (Physics.Raycast(gameObject.transform.position + new Vector3(0, 0, 0.25f), Vector3.forward, out hit, 1000))
            {
                if (hit.transform.gameObject.name == "Tool_Grinding_Plate")
                {
                    emissionModule.enabled = true;
                }
            }
            else
            {
                emissionModule.enabled = false;
            }
        }
    }

    void OnMouseDown()
    {
        isClicked = true;
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
