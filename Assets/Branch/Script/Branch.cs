using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public static int BranchCount = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BranchCount++;
            Debug.Log("Branch count: " + BranchCount);
            StartCoroutine(DeactivateAfterSeconds(1.5f));
        }
    }

    IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
