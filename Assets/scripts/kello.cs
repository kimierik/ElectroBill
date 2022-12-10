using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;


public class kello : MonoBehaviour
{
    public TMP_Text aika_text;
    public GameObject UI;
    public GameObject gameover;
    public GameObject player;
    public int aika_tunti=16;
    int aika_minuutti=0;
    public TMP_Text scoreboard;
    string url = "172.30.139.31/unity/manage_request.php";

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        StartCoroutine(Kello());
    }


    IEnumerator Kello()
    {
        // Laskuri, joka py�ritt�� kelloa eteenp�in
        // i= milloin p�iv� alkaa, i< mihin aikaan p�iv� p��ttyy
        // Tunnin pituus kellossa on waitforseconds(ARVO)

        
        
        while (aika_tunti < 17){
            aika_text.text=string.Format("{0}:{1:00}",aika_tunti,aika_minuutti);
            aika_minuutti+=1;
            if (aika_minuutti==60){
                aika_minuutti=0;
                aika_tunti++;
            }
            yield return new WaitForSeconds(1);
        }


        


        // Kun p�iv� p��ttyy, shit (gg-ui) happens
        gameover.SetActive(true);
        UI.SetActive(false);
        GameObject.Find("popup").SetActive(false);
        //player.GetComponent<Chill_charactercontroler>().enabled = false;
        player.GetComponent<Chill_charactercontroler>().game_over = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Ladataan Scoreboard tässä koska gameoverUI:ssä se ei toimi (varmaan koska canvas ensin deaktivoituu ja sitten aktivoidaan uudestaan emt)
        StartCoroutine(SendGR());

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
}