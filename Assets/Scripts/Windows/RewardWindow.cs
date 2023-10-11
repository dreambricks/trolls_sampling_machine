using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RewardWindow : MonoBehaviour
{
    [SerializeField] private CTAWindow cTAWindow;
    public string url;

    public ArduinoCommunicationReceiver arduinoCommunicationReceiver;
    public string data;

    public float totalTimeB;
    private float currentTimeB;

    public float totalTime;
    private float currentTime;

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

            startReceivingData=true;

        }
    }

    private void GetArduinoData()
    {

        data = arduinoCommunicationReceiver.GetLastestData();

        if (startReceivingData && data == "A")
        //if (data == "A")
        {
            data = "";
            startReceivingData = false;
            GoToCTAWindow();
        }


    }

    private void GoToCTAWindow()
    {
        cTAWindow.Show();
        StartCoroutine(RunMachine());
        StartCoroutine(BlockUser());
        LogUtil.SendLog(StatusEnum.AcaoConcluida);
        Hide();
    }

    public void Countdown()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;

            cTAWindow.Show();
            LogUtil.SendLog(StatusEnum.CantouMasNaoPegouPremio);
            Hide();
        }
    }

    IEnumerator RunMachine()
    {
        string fullUrl = url + "/dispensegift";

        using (UnityWebRequest www = UnityWebRequest.Get(fullUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"Error: {www.error}");
            }
            else
            {
                Debug.Log($"Received: {www.downloadHandler.text}");
            }
        }
    }

    IEnumerator BlockUser()
    {
        string fullUrl = url + ":5000/block-user";

        using (UnityWebRequest www = UnityWebRequest.Get(fullUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"Error: {www.error}");
            }
            else
            {
                Debug.Log($"Received: {www.downloadHandler.text}");
            }
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
