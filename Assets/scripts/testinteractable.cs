using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinteractable : interactable
{
    void Update()
    {
        if (interacted){
            interacted=false;
            ui.change_text_item("obname","i am a washing machine");
            ui.change_button_item_text("option1"," laita päälle");
            ui.change_button_item_text("option2"," sammuta");
        }
    }

    public override void option1_interact(){
        Debug.Log("option1 testmachine");
    }
    public override void option2_interact(){
        Debug.Log("option2 testmachine");
    }
}
