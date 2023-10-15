using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeWindow : MonoBehaviour
{
    [SerializeField] private CountDownWindow countDownWindow;
    [SerializeField] private CTAWindow cTAWindow;

    public float totalTime;
    private float currentTime;

    public UDPReceiver udpReceiver;


    private void OnEnable()
    {
        currentTime = totalTime;
        SendLightButton("true");
    }


    private void Update()
    {
        Countdown();
        ButtonPressed();
    }

    private void SendLightButton(string answer)
    {
        string url = GameManager.GetAPIUrl();
        string fullUrl = url + "/bt_light/" + answer;

        WebRequests.Get(fullUrl,
            (string error) => { Debug.Log("Error!\n" + error); },
            (string result) => { Debug.Log(result); }
           );
    }


    private void ButtonPressed()
    {
        string data = udpReceiver.GetLastestNewData(1.0f);// don't get data that is older than 1 second
        if (data == "bt_pressed" || Input.GetKeyDown("space"))
        {
            SendLightButton("false");
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
