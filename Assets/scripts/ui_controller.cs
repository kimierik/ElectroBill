using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ui_controller : MonoBehaviour
{

    public Canvas asd;
    public player_interact_script player;
    public GameObject parent_container;

    void Start(){
        parent_container=GameObject.Find("popup_ui_parent");
        GameObject tmp = GameObject.Find("popup");
        asd=tmp.GetComponent<Canvas>();
    }

    public void clear_ui(){
        foreach ( Transform child in parent_container.transform){
            GameObject.Destroy(child.gameObject);
        }
    }
   
    public void enable_canvas(){
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
    }

    public void disable_canvas(){
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        clear_ui();
    }

    public void option1_select(){
        player.currently_interacting.GetComponent<interactable>().option1_interact();
    }
    public void option2_select(){
        player.currently_interacting.GetComponent<interactable>().option2_interact();
    }



}

