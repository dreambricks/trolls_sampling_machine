using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class KaraokeWindow : MonoBehaviour
{
    [SerializeField] private RewardWindow rewardWindow;

    public VideoPlayer player;

    private void Start()
    {
        player.loopPointReached += OnVideoFinished;
    }


    private void OnEnable()
    {
        if (!player.isPlaying)
        {
            player.Play();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            rewardWindow.Show();
            Hide();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        rewardWindow.Show();
        Hide();
    }

    private void OnDisable()
    {
        player.Stop();   
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
