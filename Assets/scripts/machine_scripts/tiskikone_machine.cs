using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiskikone_machine : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Tiskaus, nimi="tiskikone", valinnat=new Dictionary<string,float>(){ {"50 asteen ohjelma",0.8f}, {"40 asteen ohjelma ",0.4f} }};}}
    
    public override string tieto_plajays {get{return "Tietoisku: 10 asteen pesulämpötilan lasku voi säästää jopa 50% energiaa";}} 

    public override void option1_interact(){
        add_item_option_to_total_value(1);
    }

    public override void option2_interact(){
        add_item_option_to_total_value(2);
    }

}
