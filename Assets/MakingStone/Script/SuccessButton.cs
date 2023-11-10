using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SuccessButton : MonoBehaviour
{
    public GameObject StudyUI;
    public GameObject Success_Modal;
    public GameObject TtenSeokgiUI;



    public void OnClick()
    {
        Success_Modal.SetActive(false);
        TtenSeokgiUI.SetActive(false);
        StudyUI.SetActive(true);
    }
}
