using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffemachine : interactable
{
    void Update()
    {
        if (interacted){
            interacted=false;
            ui.change_text_item("obname","i am a coffee machine");
            ui.change_button_item_text("option1"," keitä ");
            ui.change_button_item_text("option2"," elä keitä");
        }
    }

    public override void option1_interact(){
        Debug.Log("option 1 coffemachine");
    }
    public override void option2_interact(){
        Debug.Log("option2 coffemachine");
    }
}
