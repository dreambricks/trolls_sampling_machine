using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private CTAWindow ctaWindow;
    [SerializeField] private CountDownWindow countDownWindow;
    [SerializeField] private KaraokeWindow karaokeWindow;
    [SerializeField] private CongratulationsWindow congratulationsWindow;
    [SerializeField] private RewardWindow rewardWindow;
    [SerializeField] private ThankYouWindow thankYouWindow;
    
    void Start()
    {
        ctaWindow.Show();
        countDownWindow.Hide();
        karaokeWindow.Hide();
        congratulationsWindow.Hide();
        rewardWindow.Hide();
        thankYouWindow.Hide();
    }

}
