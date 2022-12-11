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
            fulltxt+=string.Format("{0}:00  {1} €/kwh\n",hinta_taulu.ElementAt(i).Key,hinta_taulu.ElementAt(i).Value );
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
    }
}
