using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinteractable : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Pyykki, nimi="pyykinpesukone", valinnat=new Dictionary<string,float>(){ {"40 asteen ohjelma",0.5f}, {"60 asteen ohjelma",1f} }};}}
    

    public override string tieto_plajays {get{return "Tietoisku: Pesulämpötilan lasku 60 asteesta 40 asteeseen puolittaa energiankulutuksen.";}} 

    public override void option1_interact(){
        add_item_option_to_total_value(1);
    }
    public override void option2_interact(){
        add_item_option_to_total_value(2);
    }
}
