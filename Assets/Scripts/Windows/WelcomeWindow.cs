using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWindow : MonoBehaviour
{
    [SerializeField] private CountDownWindow countDownWindow;
    [SerializeField] private CTAWindow cTAWindow;

    public float totalTime;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        Countdown();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToCountDownWindow();
        }
    }

    private void GoToCountDownWindow()
    {
        countDownWindow.Show();
        Hide();
    }

    public void Countdown()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;

            cTAWindow.Show();
            LogUtil.SendLog(StatusEnum.TermosAceitoNaoCantou);
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
