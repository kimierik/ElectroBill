using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffemachine : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Ruoka, nimi="kahvinkeitin", valinnat=new Dictionary<string,float>(){ {"keitä_kahvi",50f}, {"elä keitä kahvi",0f} }};}}

    public override void option1_interact(){
        Debug.Log("option 1 coffemachine");
        add_item_option_to_total_value(1);
    }
    public override void option2_interact(){
        Debug.Log("option2 coffemachine");
        add_item_option_to_total_value(2);
    }
}
