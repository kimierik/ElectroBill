using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sisälämpö_machine : interactable
{

    public override Item tavara{get{ return new Item(){toiminto=Toiminto.Lämmitys, nimi="sisälämpö", valinnat=new Dictionary<string,float>(){ {"pidä lämpötila ennallaan",27f}, {"laske lämpötilaa 2 astetta ",24f} }};}}

    
    public override string tieto_plajays {get{return "Tietoisku: 1 asteen lasku sisälämpötilassa voi säästää vuodessa noin 500kWh.";}} 

    public override void option1_interact(){
        add_item_option_to_total_value(1);
    }
    public override void option2_interact(){
        add_item_option_to_total_value(2);
    }
}
