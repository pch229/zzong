using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotSpeed = 20f;

    private void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
    }
}
