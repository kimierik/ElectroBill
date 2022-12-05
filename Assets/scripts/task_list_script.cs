using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
  
public enum Toiminto {
    Siivous,
    Lämmitys,
    Tiskays,
    Pyykki,
    Ruoka,
};

public class Item{
    public Toiminto toiminto;
    public string nimi;
    public bool aktiivinen=true;
    public Dictionary<string,float> valinnat ;

    string format_dictionary(){
        string fullthing="";
        foreach (var name in this.valinnat.Keys){
            fullthing+= string.Format("\n{0} :  {1}kw/h, ", name,valinnat[name]);
        }
        return fullthing;
    }

    public string get_txt(){
        return string.Format("{0}: {1},   ",this.toiminto,this.nimi);
    }

    public float get_value_from_index(int index){
        return valinnat.ElementAt(index).Value;
    }
}

public class task_list_script : porssisahko {
    public List<Item> lista=new List<Item>();
    float kulutus;
    float veloitus;
    public GameObject prefa;
    GameObject list_parent;
    Text wattmeter;
    public TMP_Text finalkulutus;
    public TMP_Text finalsumma;
    public TMP_Text completed;

    void Start(){
        list_parent= GameObject.Find("todolist_parent");
        wattmeter=GameObject.Find("wattmeter").GetComponent<Text>();

        update_wattmeter();
        //unity lataa gameobjektit eri tahtiin joten kutsuaan hetken kuluttua
        Invoke("reset_and_update_tasklist",0.1f);
        init_sahkotaulu();
    }

    
    void reset_and_update_tasklist(){
        reset_tasklist();
        update_todo_list();
    }

    void update_wattmeter(){
        reset_and_update_tasklist();
        wattmeter.text=string.Format("wattage used : {0} kwh", kulutus);
        // Suoritettavien toimintojen määrä tason läpäisyyn
        int goal = 2;
        // Jos kaikki toiminnot on tehty, kenttä on läpäisty
        if (lista.Count == goal)
        {
            completed.text = "Taso 1 suoritettu";
        }
    }
    
    //3 eri tapaa päivittää totalcost. käytä mitä haluat.
    public void update_cost_val(Item task, float value){
        kulutus+=value;
        task.aktiivinen=false;
        update_wattmeter();
    }


    // Tämä käytössä!
    public void update_cost_index(Item task,int index){
        kulutus+=task.get_value_from_index(index-1);
        veloitus += task.get_value_from_index(index - 1) * hinta;
        finalkulutus.text = kulutus.ToString();
        finalsumma.text = veloitus.ToString();
        task.aktiivinen=false;
        update_wattmeter();
    }

    public void update_cost_key(Item task, string option){
        kulutus+=task.valinnat[option];
        task.aktiivinen=false;
        update_wattmeter();
    }

    public Item find_item_from_lista(string item_name){
        for (int i =0; i<lista.Count;i++){
            if (lista[i].nimi==item_name){
                return lista[i];
            }
        }
        return null;
    }

    //monta aktiivista toimintoa on listassa
    public int get_number_of_toiminto(Toiminto etsitty){
        int count=0;
        for (int i =0; i<lista.Count;i++){
            if (lista[i].aktiivinen && lista[i].toiminto==etsitty){
                count++;
            }
        }
        return count;
    }


    public void update_todo_list(){
        int i=0;
        int x_offset=100;
        int y_offset=20;
        foreach(Toiminto toim in System.Enum.GetValues(typeof(Toiminto))){
            var thing =Instantiate(prefa,new Vector3(x_offset,-120-y_offset*i,0),Quaternion.identity);
            thing.GetComponent<Text>().text= string.Format("{0} : {1} ",toim,get_number_of_toiminto(toim));
            thing.transform.SetParent(list_parent.transform,false);
            i++;
        }
    }

    void reset_tasklist(){
        foreach ( Transform child in list_parent.transform){
            GameObject.Destroy(child.gameObject);
        }
    }
    //debug code
    public void update_tasklist(){
        int x_offset=100;
        int y_offset=20;
        for (int i =0; i<lista.Count;i++){
            if (lista[i].aktiivinen==true){
                var thing =Instantiate(prefa,new Vector3(x_offset,-120-y_offset*i,0),Quaternion.identity);
                thing.GetComponent<Text>().text=lista[i].get_txt();
                thing.transform.SetParent(list_parent.transform,false);
            }
        }
    }
}
