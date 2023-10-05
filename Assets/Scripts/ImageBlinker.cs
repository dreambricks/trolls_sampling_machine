using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageBlinker : MonoBehaviour
{
    public Color greenColor; // A cor verde que você deseja usar.
    private Color originalColor; // A cor original da imagem.
    public Image image; // A referência ao componente Image.
    public float fadeDuration = 0.25f; // Duração do fade-in e fade-out em segundos.

    private Coroutine currentFadeCoroutine;

    private void Start()
    {
        originalColor = image.color;
    }

    public void TurnGreen()
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeToGreen());
    }

    public void TurnBackToOriginal()
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeToOriginal());
    }

    private IEnumerator FadeToGreen()
    {
        float timer = 0f;
        Color startColor = image.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            image.color = Color.Lerp(startColor, greenColor, t);
            yield return null;
        }

        image.color = greenColor;
    }

    private IEnumerator FadeToOriginal()
    {
        float timer = 0f;
        Color startColor = image.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            image.color = Color.Lerp(startColor, originalColor, t);
            yield return null;
        }

        image.color = originalColor;
    }
}
