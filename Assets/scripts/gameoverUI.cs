using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class gameoverUI : MonoBehaviour
{
    public TMP_Text scoreboard;
    string url = "172.30.139.31/unity/manage_request.php";
    public Button restartbtn;
    public Button menubtn;

    // Start is called before the first frame update
    void Start()
    {
        restartbtn.onClick.AddListener(LevelOneLoader);
        Debug.Log("LevelOneLoader addded");
        menubtn.onClick.AddListener(ReturnToMenu);
        Debug.Log("ReturnToMenu addded");
        // StartCoroutine(SendGR());
        Debug.Log("Start SendGR");
    }

    void LevelOneLoader()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }

    IEnumerator SendGR()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + "/?unityget="))
        {

            Debug.Log("Using UnityWebRequest");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                scoreboard.text = responseText;
                Debug.Log(responseText);
            }
        }
    }
}