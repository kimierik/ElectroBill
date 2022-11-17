using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public bool interacted=false;
    public ui_controller ui;




    //this scriopt has some way to  interact with it
    public void interact_action(){
        //this is shot when player goes near the object and is interacted with
        ui.enable_canvas();
        interacted=true;
    }

    void OnTriggerStay(Collider collisioninfo){
        player_interact_script player = collisioninfo.gameObject.GetComponent<player_interact_script>();
        if (player !=null){
            if (player.pressed){
                player.currently_interacting=this.gameObject;
                interact_action();
                //give this interactavle to player?
                player.pressed=false;
            }
        }
    }


    public abstract void option1_interact();
    public abstract void option2_interact();



}
