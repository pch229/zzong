using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneControll : MonoBehaviour
{
    public GameObject opCinematic;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoPlaybackComplete;
    }
    private void OnVideoPlaybackComplete(VideoPlayer vp)
    {
        // 비디오 재생이 완료되면 호출됩니다.
        // 다음 씬으로 전환합니다.
        SceneManager.LoadScene("1_Cave");
    }
    public void InGameChanger()
    {
        opCinematic.SetActive(true);
        //SceneManager.LoadScene("4_Forest");      
    }

    public void WorkingSceneChanger()
    {
        SceneManager.LoadScene("Working Scene");
    }

    public void CaveSceneChanger()
    {
        SceneManager.LoadScene("1_Cave");
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


}
