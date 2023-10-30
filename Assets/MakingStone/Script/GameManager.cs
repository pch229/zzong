using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject resultModalObj;

    bool isGameFinish = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameFinish)
        {
            resultModalObj.SetActive(true);
        }
    }

    public void SetGameResult(bool result)
    {
        isGameFinish = result;
    }

    public bool GetGameResult()
    {
        return isGameFinish;
    }
}
