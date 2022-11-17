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
        if (Input.GetButtonUp("e")){
            pressed=false;
        }
    }
}
