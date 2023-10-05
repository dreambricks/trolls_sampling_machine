using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CTAWindow : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private CountDownWindow countDownWindow;
    public UDPReceiver udpReceiver;
    public string uri;


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
            countDownWindow.Show();
            Hide();
        }
    }

    void GetNewQRCode()
    {

        string uritext = uri;
        WebRequests.GetTexture(uritext,
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
