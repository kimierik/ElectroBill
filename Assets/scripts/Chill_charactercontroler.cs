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

    public bool game_over=false;
    public bool is_win=false;
    bool started_cele=false;
    public GameObject cam;
    public Animator billian_animator;
    GameObject billiam_charactermodel;

    void Start() {
        cc=gameObject.GetComponent<CharacterController>();
        billiam_charactermodel= GameObject.Find("Celebration_Bili");
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    void Update() {
        if (!game_over){
            handle_inputs();
            handle_movement();
            handle_rotate();
        }
        handle_animation();
    }


    void handle_animation(){
        if (forward_movement==0){
            billian_animator.SetBool("is_walking",false);
        }else{
            billian_animator.SetBool("is_walking",true);
        }
        if (game_over){
            //ettei king billian the third esquire true homie status teleporttais tolla transform.position argumentin takia. tää funktio kuitenkin kutsutaan loopista
            if (!started_cele){
                if (is_win){
                    billiam_charactermodel.transform.Rotate(0,180,0);        
                    billiam_charactermodel.transform.position+=transform.forward*2;

                    billian_animator.SetBool("is_celebrate",game_over);
                    started_cele=true; 
                }
            }
            }

    }
    
    void handle_movement(){
        Vector3 movedir= transform.forward*(forward_movement*(1)) + transform.right*(side_movement*(1)) + transform.up*-1;
        cc.Move(MS*Time.deltaTime*movedir);
    }

    void handle_inputs(){
        side_movement=Input.GetAxis("Horizontal");
        forward_movement=Input.GetAxis("Vertical");
        //game_over=Input.GetButtonDown("Fire1");
    }

    void handle_rotate(){
        float hrot=Input.GetAxis("Mouse X");
        float vrot=Input.GetAxis("Mouse Y");
        transform.Rotate(0,hrot*sens,0);
    }

}
