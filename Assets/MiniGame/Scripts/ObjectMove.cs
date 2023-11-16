using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float objSpeed = 10f;

    private void Update()
    {
        if (transform.position.y <= -4.1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.down * objSpeed * Time.deltaTime);
        }
    }
}
