using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public ui_controller ui;

    void Start(){
        //find and set ui item
        GameObject tmp= GameObject.Find("world_manager");
        ui=tmp.GetComponent<ui_controller>();
    }

    public void interact_action(){
        change_machine_popup();
        ui.enable_canvas();
    }

    void OnTriggerStay(Collider collisioninfo){
        player_interact_script player = collisioninfo.gameObject.GetComponent<player_interact_script>();
        if (player !=null){
            if (player.pressed){
                //tell the player that it is currently interacting with this interactable
                player.currently_interacting=this.gameObject;
                interact_action();
                player.pressed=false;
            }
        }
    }


    public abstract void change_machine_popup();
    public abstract void option1_interact();
    public abstract void option2_interact();



}
