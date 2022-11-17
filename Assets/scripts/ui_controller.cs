using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ui_controller : MonoBehaviour
{

    public Canvas asd;
    GameObject list;
    public player_interact_script player;
    Text uitext;

    void Start(){
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





    public void change_text_item(string item_name, string itemvalue){
        for (int i=0;i<asd.transform.childCount;i++){
            GameObject child = asd.gameObject.transform.GetChild(i).gameObject;
            if (child.name ==item_name){
                uitext=child.GetComponent<Text>();
                uitext.text=itemvalue;
            }
        }
    }

    public void change_button_item_text(string button_name,string newname){
        for (int i=0;i<asd.transform.childCount;i++){
            GameObject child = asd.gameObject.transform.GetChild(i).gameObject;
            if (child.name ==button_name){
                uitext=child.transform.GetChild(0).GetComponent<Text>();
                uitext.text=newname;
            }
        }
    }

  


    public void option1_select(){
        //we need some way to see what machine we are interacting with
        player.currently_interacting.GetComponent<interactable>().option1_interact();
    }
    public void option2_select(){
        //we need some way to see what machine we are interacting with
        player.currently_interacting.GetComponent<interactable>().option2_interact();
    }



}

