using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinteractable : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Pyykki, nimi="pyykinpesukone", valinnat=new Dictionary<string,float>(){ {"lämpötila_23",50f}, {"lämpötila_20",20f} }};}}

    public override void option1_interact(){
        Debug.Log("option1 testmachine");
        todo.update_cost_index(todo.find_item_from_lista(tavara.nimi),1);
        ui.disable_canvas();
    }
    public override void option2_interact(){
        Debug.Log("option2 testmachine");
        todo.update_cost_index(todo.find_item_from_lista(tavara.nimi),1);
        ui.disable_canvas();
    }
}
