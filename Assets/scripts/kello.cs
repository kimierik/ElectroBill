using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class kello : MonoBehaviour
{
    public TMP_Text aika_text;
    public GameObject UI;
    public GameObject gameover;
    public GameObject player;
    public int aika_tunti=16;
    int aika_minuutti=0;

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
            aika_minuutti++;
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
        player.GetComponent<Chill_charactercontroler>().enabled = false;

    }
}