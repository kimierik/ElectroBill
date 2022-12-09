using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valo_machine : interactable
{
    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Valaistus, nimi="valokatkaisin", valinnat=new Dictionary<string,float>(){ {"sammuta valot",-1.4f}, {"jätä päälle",20f} }};}}
    

    public override string tieto_plajays {get{return "Tietoisku: Muistathan aina sammuttaa ylimääräiset valot!";}} 

    GameObject scene_valo;
    GameObject scene_tummennin_block; 

    //start override koska tää on aika scuffed
    void Start(){
        //find and set ui item
        todo= GameObject.Find("world_manager").GetComponent<task_list_script>();
        GameObject tmp= GameObject.Find("world_manager");
        ui=tmp.GetComponent<ui_controller>();
        scene_valo=GameObject.Find("Directional Light");
        scene_tummennin_block=GameObject.Find("dark_shade");


        scene_tummennin_block.SetActive(false);
        todo.lista.Add(tavara);
    }


    public override void option1_interact(){
        //change
        scene_valo.SetActive(false);
        scene_tummennin_block.SetActive(true);
        add_item_option_to_total_value(1);
    }

    public override void option2_interact(){
        //change
        ui.disable_canvas();
    }
}
