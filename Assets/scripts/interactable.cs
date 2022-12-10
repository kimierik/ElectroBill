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
    public AudioSource pelaaja_audio_source;

    public AudioClip Info_text;
    public AudioClip Billiam_flavor;
    public AudioClip entry_sound;



    void Start(){
        //find and set ui item
        todo= GameObject.Find("world_manager").GetComponent<task_list_script>();
        GameObject tmp= GameObject.Find("world_manager");
        ui=tmp.GetComponent<ui_controller>();
        pelaaja_audio_source=GameObject.Find("Player").GetComponent<AudioSource>();
        //Debug.Log(pelaaja_audio_source);


        todo.lista.Add(tavara);
    }

    // koneen oma User interface
    public void spawn_pref(){
        var thing =Instantiate(UI_PREFAB,new Vector3(0,0,0),Quaternion.identity);
        thing.transform.SetParent(ui.parent_container.transform,false);
        Invoke("assign_ui_info",0.01f);
    }

    void close_fyitext_prefab(){
        pelaaja_audio_source.PlayOneShot(Billiam_flavor, 0.5f);
        ui.disable_canvas();
    }
    
    public void spawn_fyi_prefab(){
        ui.enable_canvas();
        var thing = Instantiate(ui.FYI_popup_prefab,new Vector3(0,0,0),Quaternion.identity);
        thing.transform.SetParent(ui.parent_container.transform,false);
        GameObject.Find("fyi_info").GetComponent<Text>().text=tieto_plajays;
        Invoke("assign_listeners",0.1f);
    } 
    

    public void interact_action(){
        if (todo.find_item_from_lista(tavara.nimi).aktiivinen){
            pelaaja_audio_source.PlayOneShot(entry_sound, 0.5f);
            ui.clear_ui();
            spawn_pref();
            Invoke("assign_listeners",0.1f);
            ui.enable_canvas();
        }
    }

    public void assign_listeners(){
        if (GameObject.Find("close_btn")!=null)GameObject.Find("close_btn").GetComponent<Button>().onClick.AddListener(ui.disable_canvas);
        if (GameObject.Find("option1")!=null)GameObject.Find("option1").GetComponent<Button>().onClick.AddListener(option1_interact);
        if (GameObject.Find("option2")!=null)GameObject.Find("option2").GetComponent<Button>().onClick.AddListener(option2_interact);
        if (GameObject.Find("close_btn_f")!=null)GameObject.Find("close_btn_f").GetComponent<Button>().onClick.AddListener(close_fyitext_prefab);
    }

    public void assign_ui_info(){

        if (GameObject.Find("option1")!=null)GameObject.Find("option1").transform.GetChild(0).GetComponent<Text>().text=tavara.get_key_from_index(0);
        if (GameObject.Find("option2")!=null)GameObject.Find("option2").transform.GetChild(0).GetComponent<Text>().text=tavara.get_key_from_index(1);
        if (GameObject.Find("flavor")!=null)GameObject.Find("flavor").GetComponent<Text>().text=tavara.nimi;
    }


    void OnTriggerStay(Collider collisioninfo){
        player_interact_script player = collisioninfo.gameObject.GetComponent<player_interact_script>();
        if (player !=null){
            if (player.pressed){
                ui.clear_ui();
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
        //annetaan hetki aikaa viime ikkunalle despawnaa
        Invoke("spawn_fyi_prefab",0.1f);
        pelaaja_audio_source.PlayOneShot(Info_text, 0.5f);

    }


    public abstract Item tavara {get;}
    public abstract string tieto_plajays {get;}

    public abstract void option1_interact();
    public abstract void option2_interact();



}
