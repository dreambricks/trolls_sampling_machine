using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDispenserWindow : MonoBehaviour
{

    [SerializeField] private RedeemWindow redeemWindow;
    [SerializeField] private CTAWindow cTAWindow;

    public UDPReceiver udpReceiver;

    public float totalTime;
    private float currentTime;


    private void OnEnable()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        WaitingToDropGift();
        Countdown();
    }


    private void WaitingToDropGift()
    {
        string data = udpReceiver.GetLastestNewData(1.0f);// don't get data that is older than 1 second
        if (data == "caiu" || Input.GetKeyDown("space"))
        {
            redeemWindow.Show();
            Hide();

        }

    }


    public void Countdown()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;

            cTAWindow.Show();
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
