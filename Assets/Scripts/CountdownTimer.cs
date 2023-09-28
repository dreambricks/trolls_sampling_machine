using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 10f;  // Tempo total da contagem regressiva em segundos
    public Text countdownText;
    private float currentTime;

    [SerializeField] private CountDownWindow countDownWindow;
    [SerializeField] private KaraokeWindow karaokeWindow;

    private void OnEnable()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            karaokeWindow.Show();
            countDownWindow.Hide();
        }

        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = seconds.ToString();
    }
}
