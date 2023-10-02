using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTAWindow : MonoBehaviour
{

    [SerializeField] private CountDownWindow countDownWindow;
    public UDPReceiver udpReceiver;

    // Update is called once per frame
    void Update()
    {
        Terms();
    }

    void Terms()
    {
        string data = udpReceiver.GetLastestNewData(1.0f);// don't get data that is older than 1 second
        if (data == "yes")
        {
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
