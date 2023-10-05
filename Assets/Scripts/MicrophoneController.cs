using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneController : MonoBehaviour
{
    public ImageBlinker imageBlinker;
    public float detectionThreshold = 0.1f;
    public float greenDuration = 0.5f; 

    private AudioSource audioSource;
    private bool isListening = false;
    private float greenTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { } 
        audioSource.Play();
    }

    void Update()
    {
        // Verifique o volume do �udio capturado pelo microfone.
        float[] audioData = new float[128];
        audioSource.GetOutputData(audioData, 0);

        float averageVolume = 0f;
        for (int i = 0; i < audioData.Length; i++)
        {
            averageVolume += Mathf.Abs(audioData[i]);
        }
        averageVolume /= audioData.Length;

        // Verifique se o volume � maior que o limiar de detec��o.
        if (averageVolume > detectionThreshold)
        {
            if (!isListening)
            {
                // Quando o som for detectado, fa�a a imagem piscar em verde.
                if (imageBlinker != null)
                {
                    imageBlinker.TurnGreen();
                    greenTimer = greenDuration;
                }
                isListening = true;
            }
        }
        else
        {
            if (isListening)
            {
                // Aguarde o tempo especificado antes de voltar � cor original.
                if (greenTimer > 0f)
                {
                    greenTimer -= Time.deltaTime;
                }
                else
                {
                    // Quando a detec��o de som parar, fa�a a imagem voltar � cor original.
                    if (imageBlinker != null)
                    {
                        imageBlinker.TurnBackToOriginal();
                    }
                    isListening = false;
                }
            }
        }
    }
}
