using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class CTAWindow : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private WelcomeWindow welcomeWindow;
    [SerializeField] private NotWorkingWindow notWorkingWindow; 
    
    public UDPReceiver udpReceiver;


    private void OnEnable()
    {
        GetNewQRCode();
    }

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
            if (!notWorkingWindow.isActiveAndEnabled)
            {
                welcomeWindow.Show();
                Hide();
            }
        } else if (data == "no")
        {
            LogUtil.SendLog(StatusEnum.TermosNaoAceito);
        }
    }

    void GetNewQRCode()
    {
        string url = GameManager.GetAPIUrl();
        string fullUrl = url + "/qrcode";

        WebRequests.GetTexture(fullUrl,
            (string error) => { Debug.Log("Error!\n" + error); },
            (Texture2D texture2D) =>
            {
                Debug.Log("Success getting the QRCode!\n");
                Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(.5f, .5f), 16f);
                image.sprite = sprite;
            });
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
