using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cc_movement : MonoBehaviour
{

    public Transform cameraHolder;
    public CharacterController cc;

    public GameObject wall;

    public float MS=10;
    float sens;
    public float gravity=9.81f;
    public float max_accel=4;
    public float max_jump_height=3;
    float speed_factor;//this is what gives invinite movement if you keep jumping
    public float ms_increase_on_jump =0.005f;

    bool cursor_lock_state=true;
    bool wall_transparency=true;
// these are changed over time to mimic acceleration and deceleration
        float zvelocity;
// scoped values that i can use in this script if i need to get the -1..1 value of the direction..
        float zmovement;
        float hmovement;
        float vmovement;

 //public Animator anim;


      public float acceleration;

    // Start is called before the first frame update
    void Start(){
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        //animf=GetComponent<Animator>();
        sens =2f;//PlayerPrefs.GetFloat("sensitivity");


    }



    void move(){
        if (cc.isGrounded){
            zvelocity=0;
            speed_factor*=0.9f;
            if (zmovement==1){
                zvelocity=max_jump_height;
            }
        }else{
            zvelocity-=gravity*Time.deltaTime;
            speed_factor+=ms_increase_on_jump;
            //this makes it so that we can have insane ms when jumping
        }


        update_acceleration();
//placeholder maybe removed bc i want infinite possible ms
        limit_velocity();

        //same thing but no direction on the new vec method
        Vector3 movedir= transform.forward*(vmovement*(acceleration+speed_factor)) + transform.right*(hmovement*(acceleration+speed_factor)) + transform.up*zvelocity;
        //Vector3 movedir= new Vector3(hmovement,zmovement,vmovement);
        //Debug.Log("movedir "+movedir );
        //Debug.Log("movedir2 "+movedir2);



        cc.Move(MS*Time.deltaTime*movedir);
    }


    void update_acceleration(){
       if (hmovement !=0 || vmovement!=0){
            acceleration+=0.05f;

       }else{
       if (acceleration>=0){ 
        acceleration-=0.05f;
        }
        
        } 


    }

    void limit_velocity(){
        if(acceleration>=max_accel){
            acceleration=max_accel-0.1f;
        }
    }
void inputs(){
     hmovement=Input.GetAxis("Horizontal");
     vmovement=Input.GetAxis("Vertical");
     zmovement=Input.GetAxis("Jump");



    //anim.SetBool("iswalk",true);

}

    void escmenu(){

        //to see if we are pressing button
        if(Input.GetButtonDown("esc")){
            if(cursor_lock_state){
                Cursor.lockState=CursorLockMode.Locked;
                Cursor.visible=false;
            }else{
                Cursor.lockState=CursorLockMode.None;
                Cursor.visible=true;
            }


            cursor_lock_state=!cursor_lock_state;
        }


    }



    void rotate(){
        float hrot=Input.GetAxis("Mouse X");
        float vrot=Input.GetAxis("Mouse Y");
        transform.Rotate(0,hrot*sens,0);
        //cameraHolder.Rotate(-vrot*sens,0,0);

        //copied off the interner
        //magic bnumbers are uplimit and downlimit respectivl
        Vector3 currot= cameraHolder.localEulerAngles;
        if(currot.x>180) currot.x-=360;
        currot.x=Mathf.Clamp(currot.x,-50,50);
        cameraHolder.localRotation=Quaternion.Euler(currot);

    }


    void toggle_wall_transparency(){

        if(Input.GetButtonDown("Fire1")){
            if (wall_transparency){
                wall_transparency=false;
                wall.GetComponent<Renderer>().material.SetFloat("_Size", 0.0f);
            }else{
                wall_transparency=true;
                wall.GetComponent<Renderer>().material.SetFloat("_Size", 0.3f);
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        if(cc.isGrounded){
        inputs();
        }
        rotate();
        move(); 
        escmenu();
        toggle_wall_transparency();
    }
}
