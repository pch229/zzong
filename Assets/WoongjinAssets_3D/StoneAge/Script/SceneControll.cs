using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    public void InGameChanger()
    {
        SceneManager.LoadScene("4_Forest");      
    }

    public void WorkingSceneChanger()
    {
        SceneManager.LoadScene("Working Scene");
    }

    public void CaveSceneChanger()
    {
        SceneManager.LoadScene("1_Cave");
    }

    public void StudyUIStart()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("1_Cave");
        }

        if (other.CompareTag("toForest"))
        {
            SceneManager.LoadScene("4_Forest");
        }

    }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
