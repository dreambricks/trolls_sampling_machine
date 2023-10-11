using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWindow : MonoBehaviour
{
    [SerializeField] private CountDownWindow countDownWindow;
    [SerializeField] private CTAWindow cTAWindow;

    public ArduinoCommunicationReceiver arduinoCommunicationReceiver;

    public float totalTime;
    private float currentTime;


    public float totalTimeB;
    private float currentTimeB;

    public string data;

    private bool startReceivingData;



    private void OnEnable()
    {
        currentTime = totalTime;

        totalTimeB = 1;
        currentTimeB = totalTimeB;

        data = "";
        startReceivingData = false;
    }


    private void Update()
    {
        Countdown();

        GetArduinoData();

        CountDownReceiving();
    }

    private void CountDownReceiving()
    {
        currentTimeB -= Time.deltaTime;

        if (currentTimeB <= 0)
        {
            currentTimeB = 0;

            startReceivingData = true;

        }
    }

    private void GetArduinoData()
    {
        data = arduinoCommunicationReceiver.GetLastestData();

        if (startReceivingData && data == "A")
        {
            data = "";
            startReceivingData = false;
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
