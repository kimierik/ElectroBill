using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ui_controller : MonoBehaviour
{

    public player_interact_script player;
    public GameObject parent_container;
    public GameObject FYI_popup_prefab;

    void Start(){
        parent_container=GameObject.Find("popup_ui_parent");
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

    public void instantiate_FYI_popup(string fyi_text){
        enable_canvas();
        var thing =Instantiate(FYI_popup_prefab,new Vector3(0,0,0),Quaternion.identity);
        thing.transform.SetParent(parent_container.transform,false);
        GameObject.Find("fyi_info").GetComponent<Text>().text=fyi_text;

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

