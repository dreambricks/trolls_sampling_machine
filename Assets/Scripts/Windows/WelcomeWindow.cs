using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWindow : MonoBehaviour
{
    [SerializeField] private CountDownWindow countDownWindow;

    public float totalTime;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        Countdown();
    }

    public void Countdown()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            countDownWindow.Show();
            Hide();
        }
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
