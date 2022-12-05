using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chill_charactercontroler : MonoBehaviour
{
    
    float side_movement;
    float forward_movement;
    float hrot,vrot;
    public CharacterController cc;
    public float MS=2;
    float sens=2;

    public GameObject cam;
    public Animator billian_animator;

    void Start() {
        cc=gameObject.GetComponent<CharacterController>();
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    void Update() {
        handle_inputs();
        handle_movement();
        handle_rotate();

        handle_animation();
    }


    void handle_animation(){
        if (forward_movement==0){
            billian_animator.SetBool("Is_walking",false);
        }else{

            billian_animator.SetBool("Is_walking",true);
        }
    }
    
    void handle_movement(){
        Vector3 movedir= transform.forward*(forward_movement*(1)) + transform.right*(side_movement*(1)) + transform.up*-1;
        cc.Move(MS*Time.deltaTime*movedir);
    }

    void handle_inputs(){
        side_movement=Input.GetAxis("Horizontal");
        forward_movement=Input.GetAxis("Vertical");
    }

    void handle_rotate(){
        float hrot=Input.GetAxis("Mouse X");
        float vrot=Input.GetAxis("Mouse Y");
        transform.Rotate(0,hrot*sens,0);
    }

}
