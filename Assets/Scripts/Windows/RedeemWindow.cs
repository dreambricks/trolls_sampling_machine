using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeemWindow : MonoBehaviour
{

    public float totalTime;
    private float currentTime;

    [SerializeField] private CTAWindow cTAWindow;


    private void OnEnable()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
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
