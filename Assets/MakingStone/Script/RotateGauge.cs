using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotateGauge : MonoBehaviour
{
    [SerializeField] RectTransform parentRectTransform;
    [SerializeField] float speed = 2.0f;  // ¼Óµµ
    [SerializeField] bool isHitTiming = false;

    RectTransform gaugeRectTransform;

    float angle = 0;
    float radius = 0;
    int arrowDir = 1;

    void Start()
    {
        gaugeRectTransform = GetComponent<RectTransform>();

        radius = parentRectTransform.sizeDelta.x / 2;
    }

    void Update()
    {
        Vector2 newPos = Vector2.zero - gaugeRectTransform.anchoredPosition;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg + 180;
        // Debug.Log(rotZ);
        if(rotZ >= 50 && rotZ <= 138)
        {
            isHitTiming = true;
        }
        else
        {
            isHitTiming = false;
        }
        gaugeRectTransform.rotation = Quaternion.Euler(0, 0, rotZ);

        angle += speed * Time.deltaTime * arrowDir;
        gaugeRectTransform.anchoredPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GaugePoint")
        {
            arrowDir *= -1;
        }
    }
}
