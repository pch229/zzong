using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenCanvas : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    void Awake()
    {
        int invenCount = GameObject.FindGameObjectsWithTag("InvenSingleTon").Length;

        if (invenCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetActiveInven(bool isActive)
    {
        inventory.SetActive(isActive);
    }
}
