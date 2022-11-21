using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffemachine : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Ruoka, nimi="kahvinkeitin", valinnat=new Dictionary<string,float>(){ {"keitä_kahvi",50f}, {"elä keitä kahvi",0f} }};}}

    public override void option1_interact(){
        Debug.Log("option 1 coffemachine");
        todo.update_cost(todo.find_item_from_lista(tavara.nimi),"keitä_kahvi");
        ui.disable_canvas();
    }
    public override void option2_interact(){
        Debug.Log("option2 coffemachine");
        todo.update_cost(todo.find_item_from_lista(tavara.nimi),"elä keitä kahvi");
        ui.disable_canvas();
    }
}
