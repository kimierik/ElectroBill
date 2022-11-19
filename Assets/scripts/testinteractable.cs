using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinteractable : interactable
{


    public override void option1_interact(){
        Debug.Log("option1 testmachine");
        todo.update_cost(todo.find_item_from_lista("pyykinpesukone"),"lämpötila_23");
        ui.disable_canvas();
    }
    public override void option2_interact(){
        Debug.Log("option2 testmachine");
        todo.update_cost(todo.find_item_from_lista("pyykinpesukone"),"lämpötila_20");
        ui.disable_canvas();
    }
}
