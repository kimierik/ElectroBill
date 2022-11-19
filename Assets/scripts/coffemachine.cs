using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffemachine : interactable
{


    public override void option1_interact(){
        Debug.Log("option 1 coffemachine");
        todo.update_cost(todo.find_item_from_lista("kahvinkeitin"),"keitä_kahvi");
        ui.disable_canvas();
    }
    public override void option2_interact(){
        Debug.Log("option2 coffemachine");
        todo.update_cost(todo.find_item_from_lista("kahvinkeitin"),"elä keitä kahvi");
        ui.disable_canvas();
    }
}
