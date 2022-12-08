using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suihku_machine : interactable
{
    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Siivous, nimi="suihku", valinnat=new Dictionary<string,float>(){ {"lämmin suihku",2.1f}, {"viileä suihku",1.4f} }};}}
    
    public override string tieto_plajays {get{return " Tietoisku: 10 astetta viileämpi suihkuvesi voi säästää jopa 33% energiaa.";}} 

    public override void option1_interact(){
        add_item_option_to_total_value(1);
    }

    public override void option2_interact(){
        add_item_option_to_total_value(2);
    }
}
