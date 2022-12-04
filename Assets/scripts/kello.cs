using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class kello : MonoBehaviour
{
    public TMP_Text aika;
    public GameObject UI;
    public GameObject gameover;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        StartCoroutine(Kello());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Kello()
    {
        // Laskuri, joka pyörittää kelloa eteenpäin
        // i= milloin päivä alkaa, i< mihin aikaan päivä päättyy
        // Tunnin pituus kellossa on waitforseconds(ARVO)
        for (int i=7; i<22; i++)
        {
            aika.text = i + ":00";
            yield return new WaitForSeconds(1);

        }

        // Kun päivä päättyy, shit (gg-ui) happens
        gameover.SetActive(true);
        UI.SetActive(false);
        player.GetComponent<Chill_charactercontroler>().enabled = false;

    }
}
