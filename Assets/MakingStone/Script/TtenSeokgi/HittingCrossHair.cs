using UnityEngine;

public class HittingCrossHair : MonoBehaviour
{
    bool isOnTarget;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TtenSeokgi")
        {
            isOnTarget = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TtenSeokgi")
        {
            isOnTarget = false;
        }
    }

    public bool GetIsOnTarget()
    {
        return isOnTarget;
    }
}