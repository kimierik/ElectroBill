using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class menucontroller : MonoBehaviour
{
    public Button startgame;
    public TMP_InputField nimi;
    public Button exitbtn;

    // Start is called before the first frame update
    void Start()
    {
        startgame.onClick.AddListener(LevelOneLoader);
        exitbtn.onClick.AddListener(Yeet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelOneLoader()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        //Pelaajan nimi playername-muuttujassa!!
        string playername = nimi.text.ToString();
        Debug.Log(playername);
    }

    void Yeet()
    {
        Application.Quit();
    }
}
