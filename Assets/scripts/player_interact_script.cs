using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interact_script : MonoBehaviour
{

    public bool pressed=false;
    public GameObject currently_interacting;
    void Update(){

        if (Input.GetButtonDown("e")){
            Debug.Log("e") ;
            pressed=true;
        }
        
    }


/*
    void OnTriggerStay(Collider collisioninfo){

        if (false=true){
            Debug.Log(collisioninfo);
            interactable target = collisioninfo.gameObject.GetComponent<interactable>();
            Debug.Log(target);
            if (target!=null){
                target.interact_action();
                Debug.Log("id why this has to be here") ;
            }
            pressed=false;
        }


    }
 */   


}
