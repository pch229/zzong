using UnityEngine;

public class HittingCrossHair : MonoBehaviour
{
    bool isOnTarget;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "1_Handaxe")
        {
            isOnTarget = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "1_Handaxe")
        {
            isOnTarget = false;
        }
    }

    public bool GetIsOnTarget()
    {
        return isOnTarget;
    }
}