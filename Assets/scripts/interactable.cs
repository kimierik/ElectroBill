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
        if (todo.find_item_from_lista(tavara.nimi).aktiivinen){
            ui.clear_ui();
            spawn_pref();
            assign_listeners();
            ui.enable_canvas();
        }
    }

    public void assign_listeners(){
        if (GameObject.Find("close_btn")!=null)GameObject.Find("close_btn").GetComponent<Button>().onClick.AddListener(ui.disable_canvas);
        if (GameObject.Find("option1")!=null)GameObject.Find("option1").GetComponent<Button>().onClick.AddListener(option1_interact);
        if (GameObject.Find("option2")!=null)GameObject.Find("option2").GetComponent<Button>().onClick.AddListener(option2_interact);
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

    public void add_item_option_to_total_value(int index){
        todo.update_cost_index(todo.find_item_from_lista(tavara.nimi),index);
        ui.disable_canvas();
    }


    public abstract Item tavara {get;}

    public abstract void option1_interact();
    public abstract void option2_interact();



}
