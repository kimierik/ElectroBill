using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public ui_controller ui;
    public task_list_script todo;
    public GameObject UI_PREFAB;

    void Start(){
        //find and set ui item
        todo= GameObject.Find("world_manager").GetComponent<task_list_script>();
        GameObject tmp= GameObject.Find("world_manager");
        ui=tmp.GetComponent<ui_controller>();
        todo.lista.Add(tavara);
    }

    public void spawn_pref(){
        var thing =Instantiate(UI_PREFAB,new Vector3(0,0,0),Quaternion.identity);
        thing.transform.SetParent(ui.parent_container.transform,false);
    }

    public void interact_action(){
        ui.clear_ui();
        spawn_pref();
        assign_listeners();
        ui.enable_canvas();
    }

    void assign_listeners(){
        GameObject.Find("close_btn").GetComponent<Button>().onClick.AddListener(ui.disable_canvas);
        GameObject.Find("option1").GetComponent<Button>().onClick.AddListener(option1_interact);
        GameObject.Find("option2").GetComponent<Button>().onClick.AddListener(option2_interact);
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

    public abstract Item tavara {get;}

    public abstract void option1_interact();
    public abstract void option2_interact();



}
