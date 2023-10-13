using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckWork : MonoBehaviour
{
    [SerializeField] private CTAWindow ctaWindow;
    [SerializeField] private NotWorkingWindow notWorkingWindow;
    [SerializeField] private MaintWindow maintWindow;

    public int checkIntervalSeconds;
    public string response;

    public List<GameObject> gameObjectsList;

    private void Start()
    {

        StartCoroutine(Worker());
    }


    IEnumerator Worker()
    {
        string url = GameManager.GetAPIUrl();
        string fullUrl = url + "/working";

        while (true)
        {
            yield return new WaitForSeconds(checkIntervalSeconds);

            using (UnityWebRequest www = UnityWebRequest.Get(fullUrl))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogWarning("Erro na requisição: " + www.error);
                }
                else
                {
                    response = www.downloadHandler.text;
                    Debug.Log("Resposta da API: " + response);

                    if (response == "yes")
                    {
                        ExecuteMethodIfYes();
                    }
                    else if (response == "no")
                    {
                        ExecuteMethodIfNo();
                    }
                    else if (response == "maint")
                    {
                        ExecuteMethodIfMaint();
                    }
                    else
                    {
                        Debug.LogWarning("Resposta não reconhecida: " + response);
                    }
                }
            }
        }
    }

    public void DisableAllExcept(string gameObjectName)
    {
        foreach (GameObject obj in gameObjectsList)
        {
            if (obj.name != gameObjectName)
            {
                obj.SetActive(false);
            } 
            else if (obj.name == gameObjectName)
            {
                obj.SetActive(true);
            }
        }
    }


    private void ExecuteMethodIfYes()
    {
        //ctaWindow.Show();
        //notWorkingWindow.Hide();
        //maintWindow.Hide();

        DisableAllExcept("CTAWindow");
    }

    private void ExecuteMethodIfNo()
    {
        //notWorkingWindow.Show();
        //ctaWindow.Hide();
        //maintWindow.Hide();

        DisableAllExcept("NotWorkingWindow");

    }

    private void ExecuteMethodIfMaint()
    {
        maintWindow.Show();
        notWorkingWindow.Hide();
        ctaWindow.Hide();
    }
}
