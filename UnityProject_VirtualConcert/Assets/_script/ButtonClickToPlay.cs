using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class ButtonClickToPlay : MonoBehaviour
{
    public GameObject videoPlayer;

    public void clickToPlay()
    {
        videoPlayer.GetComponent<VideoPlayer>().Play();
    }

    public void clickToPause()
    {
        videoPlayer.GetComponent<VideoPlayer>().Stop();
    }
}
