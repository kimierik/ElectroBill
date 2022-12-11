using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class televisio_machine : interactable
{
    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Viihde, nimi="TV", valinnat=new Dictionary<string,float>(){ {"sarjamaratooni 5h",1f}, {"jätä katsomatta",0f} }};}}
    
    public override string tieto_plajays {get{return "Tietoisku: TV:n katselu kuluttaa n 1kWh energiaa 5 tunnin katselun aikana.";}}

    void Start()
    {
        //find and set ui item
        todo = GameObject.Find("world_manager").GetComponent<task_list_script>();
        GameObject tmp = GameObject.Find("world_manager");
        ui = tmp.GetComponent<ui_controller>();
        pelaaja_audio_source = GameObject.Find("Player").GetComponent<AudioSource>();
        //Debug.Log(pelaaja_audio_source);


        todo.lista.Add(tavara);

        volyymi = 0.1f;
    }

    public override void option1_interact(){
        add_item_option_to_total_value(1);
        //kello +5 tuntia
    }

    public override void option2_interact(){
        add_item_option_to_total_value(2);
    }

}
