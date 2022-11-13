using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_transparency_script : MonoBehaviour
{
    Renderer rend;

    public float transparency_size =0.3f;
    public float shader_ontime=1f;
    float som_time;
    

    void Start()
    {
        som_time=Time.time;
        rend=GetComponent<Renderer>();
    }
    void Update()
    {
        
        if(Time.time-som_time>shader_ontime){
            change_shader(0.0f);
        }else{
            change_shader(transparency_size);
        }
    }

    void change_shader(float value){
        rend.material.SetFloat("_Size",value);
    }


    public void apply_shader(){
        som_time=Time.time;
    }
}
