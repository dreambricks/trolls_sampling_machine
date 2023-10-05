using UnityEngine;
using UnityEngine.UI;

public class SpeechRecognition : MonoBehaviour
{
    public Image targetImage;
    public AudioSource microphoneSource;
    public float speechThreshold = 0.1f;

    private bool isSpeaking = false;

    private void Update()
    {
        // Capture o �udio do microfone
        float[] audioData = new float[microphoneSource.clip.samples];
        microphoneSource.clip.GetData(audioData, 0);

        // Calcule a intensidade sonora m�dia
        float averageVolume = 0;
        foreach (float sample in audioData)
        {
            averageVolume += Mathf.Abs(sample);
        }
        averageVolume /= audioData.Length;

        // Verifique se a intensidade sonora est� acima do limiar
        isSpeaking = averageVolume > speechThreshold;

        // Altere a cor da imagem com base na fala
        if (isSpeaking)
        {
            targetImage.color = Color.red; // Cor quando est� falando
        }
        else
        {
            targetImage.color = Color.green; // Cor quando n�o est� falando
        }
    }
}
