using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class menucontroller : MonoBehaviour
{
    public Button startgame;
    public TMP_InputField nimi;
    public Button exitbtn;
    public string PlayerName;
    public TMP_Text scoreboard;
    string url = "172.30.139.31/unity/manage_request.php";
    static string[] banned={"TABLE","table",";",":","DROP","drop"};
    List<string> banned_naming_convention= new List<string>(banned);

    // Start is called before the first frame update
    void Start()
    {
        startgame.onClick.AddListener(LevelOneLoader);
        exitbtn.onClick.AddListener(Yeet);
        StartCoroutine(SendGR());
    }


    bool string_is_sanitized(string input){
        for(int i=0;i<banned_naming_convention.Count;i++){
            if (input.Contains(banned_naming_convention[i])) {
                return false;
            }
        }
        return true;
    }    


    void LevelOneLoader()
    {
        string name = nimi.text.ToString();
        if (name != "Kirjoita nimi" && name != "" && string_is_sanitized(name)) {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            //Pelaajan nimi PlayerName-muuttujassa!!
            PlayerPrefs.SetString(PlayerName, name);
        }
        else
        {
            StartCoroutine(NimiPuuttuu());
        }
    }

    IEnumerator NimiPuuttuu()
    {
        nimi.image.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        nimi.image.color = Color.white;
    }

    void Yeet()
    {
        Application.Quit();
    }

    IEnumerator SendGR()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + "/?unityget="))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                scoreboard.text = responseText;
            }
        }
    }
}
