using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinteractable : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Pyykki, nimi="pyykinpesukone", valinnat=new Dictionary<string,float>(){ {"lämpötila_23",50f}, {"lämpötila_20",20f} }};}}

    public override void option1_interact(){
        Debug.Log("option1 testmachine");
        add_item_option_to_total_value(1);
    }
    public override void option2_interact(){
        Debug.Log("option2 testmachine");
        add_item_option_to_total_value(2);
    }
}
