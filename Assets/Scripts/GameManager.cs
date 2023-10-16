using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private CTAWindow ctaWindow;
    [SerializeField] private CountDownWindow countDownWindow;
    [SerializeField] private KaraokeWindow karaokeWindow;
    //[SerializeField] private CongratulationsWindow congratulationsWindow;
    [SerializeField] private RewardWindow rewardWindow;
    [SerializeField] private WelcomeWindow welcomeWindow;
    [SerializeField] private WaitDispenserWindow waitDispenserWindow;
    [SerializeField] private RedeemWindow redeemWindow;

    public static string apiUrl;
    
    void Start()
    {
        ctaWindow.Show();
        countDownWindow.Hide();
        karaokeWindow.Hide();
       // congratulationsWindow.Hide();
        rewardWindow.Hide();
        welcomeWindow.Hide();
    }


    public static string GetAPIUrl()
    {
        apiUrl = "http://localhost:5000";
        string url = apiUrl;
        return url;
    }
   

}
