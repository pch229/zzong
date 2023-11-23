using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class nextScene : MonoBehaviour
{
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
}
