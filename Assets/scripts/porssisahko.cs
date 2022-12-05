using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class porssisahko : MonoBehaviour

{
    public TMP_Text hinta_taulu_text;
    public kello aikalaskija;
    public float hinta = 0;
    public Dictionary<string,float> hinta_taulu=new Dictionary<string,float>(){
            {"7",0.3013f},
            {"8",0.33f},
            {"9",0.341f},
            {"10",0.33f},
            {"11",0.3629f},
            {"12",0.363f},
            {"13",0.363f},
            {"14",0.3701f},
            {"15",0.4279f},
            {"16",0.4391f},
            {"17",0.495f},
            {"18",0.4391f},
            {"19",0.4495f},
            {"20",0.3964f},
            {"21",0.3856f},
        };

    // Start is called before the first frame update
    public void init_sahkotaulu()
    {
        string fulltxt="";
        for (int i =0;i<hinta_taulu.Count;i++){
            fulltxt+=string.Format("{0}:00  {1}\n ",hinta_taulu.ElementAt(i).Key,hinta_taulu.ElementAt(i).Value );
        }
        hinta_taulu_text.text=fulltxt;
    }

    // Update is called once per frame
    void Update()
    {
        // Hinta p�ivittyy joka frame vai olisiko parempi jos se p�ivittyy aina silloin kun taski on tehty?
        // T�ll�in siirr� funktion kutsu Updaten sijaan -> task_list_script.cs update_cost_index -funktioon!
        ElectrcityPrice();
    }

    public void ElectrcityPrice()
    {
        //string tunti = aika2.text;
        hinta = hinta_taulu[aikalaskija.aika_tunti.ToString()];
        
        // S�hk�n hinta tunneittain euroina 3.12.2022
        /*
        switch (tunti)
        {
            case "7:00":
                hinta = 0.3013f;
                break;
            case "8:00":
                hinta = 0.33f;
                break;
            case "9:00":
                hinta = 0.341f;
                break;
            case "10:00":
                hinta = 0.33f;
                break;
            case "11:00":
                hinta = 0.3629f;
                break;
            case "12:00":
                hinta = 0.363f;
                break;
            case "13:00":
                hinta = 0.363f;
                break;
            case "14:00":
                hinta = 0.3701f;
                break;
            case "15:00":
                hinta = 0.4279f;
                break;
            case "16:00":
                hinta = 0.4391f;
                break;
            case "17:00":
                hinta = 0.495f;
                break;
            case "18:00":
                hinta = 0.4391f;
                break;
            case "19:00":
                hinta = 0.4495f;
                break;
            case "20:00":
                hinta = 0.3964f;
                break;
            case "21:00":
                hinta = 0.3856f;
                break;

        }

        */
    }
}
