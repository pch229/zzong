using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("종료 클릭");

        // 실제 빌드된 게임에서만 작동합니다.
        Application.Quit();
    }

    public void OnButtonClick()
    {
        Debug.Log("버튼이 클릭");
    }


}
