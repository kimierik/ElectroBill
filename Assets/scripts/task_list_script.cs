using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
  
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
}

//make someway to update the list. add all prefs in list and change them or reset the entire list
public class task_list_script : MonoBehaviour{
    List<Item> lista=new List<Item>();
    float totalcost;
    public GameObject prefa;
    GameObject list_parent;
    Text wattmeter;

    void Start(){
        list_parent= GameObject.Find("todolist_parent");
        wattmeter=GameObject.Find("wattmeter").GetComponent<Text>();
        lista.Add(new Item(){toiminto=Toiminto.Ruoka, nimi="kahvinkeitin", valinnat=new Dictionary<string,float>(){ {"keitä_kahvi",50f}, {"elä keitä kahvi",0f} }}) ;
        lista.Add(new Item(){toiminto=Toiminto.Pyykki, nimi="pyykinpesukone", valinnat=new Dictionary<string,float>(){ {"lämpötila_23",30f}, {"lämpötila_20",20f} }}) ;
        reset_tasklist();
        update_todo_list();
    }
    
    public void update_cost(Item task, string option){
        totalcost+=task.valinnat[option];
        task.aktiivinen=false;
        reset_tasklist();
        update_todo_list();
        wattmeter.text=string.Format("wattage used : {0} kwh", totalcost) ;
    }

    public Item find_item_from_lista(string item_name){
        for (int i =0; i<lista.Count;i++){
            if (lista[i].nimi==item_name){
                return lista[i];
            }
        }
        return null;
    }

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
