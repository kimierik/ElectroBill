using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ui_controller : MonoBehaviour
{

    public Canvas asd;
    public player_interact_script player;

    void Start(){
        GameObject tmp = GameObject.Find("popup");
        asd=tmp.GetComponent<Canvas>();
        asd.GetComponent<Canvas>().enabled=false;
    }
   
    public void enable_canvas(){
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
        asd.GetComponent<Canvas>().enabled=true;
    }

    public void disable_canvas(){
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        asd.GetComponent<Canvas>().enabled=false;
    }

    GameObject find_go_from_ui(string name){
        for (int i=0;i<asd.transform.childCount;i++){
            GameObject child = asd.gameObject.transform.GetChild(i).gameObject;
            if (child.name ==name){
                return child;
            }
        }
        //nullpointer exeption from hell >:D
        return null;
    }

    public void change_text_item(string item_name, string itemvalue){
        find_go_from_ui(item_name).transform.GetComponent<Text>().text=itemvalue;
    }

    public void change_button_item_text(string button_name,string newname){
        find_go_from_ui(button_name).transform.GetChild(0).GetComponent<Text>().text=newname;
    }

    public void option1_select(){
        player.currently_interacting.GetComponent<interactable>().option1_interact();
    }
    public void option2_select(){
        player.currently_interacting.GetComponent<interactable>().option2_interact();
    }



}

