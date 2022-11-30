using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_transparency_script : MonoBehaviour
{
    Renderer rend;

    public float transparency_size =0.3f;
    public float shader_ontime=1f;
    float som_time;
    bool has_ben_set=false;

    public Material Default;
    public Material transparent;

    void Start()
    {
        som_time=Time.time;
        rend=GetComponent<Renderer>();
    }

    public void set_materials(Material def, Material trans){
        Default=def;
        transparent=trans;
        has_ben_set=true;
    }

    void Update()
    {
        //katso onko shader ontime mennyt umpeen
        if (has_ben_set){
            if(Time.time-som_time>shader_ontime){
                rend.material=Default;
            }else{
                rend.material=transparent;
            }
        }
    }


    public void apply_shader(){
        som_time=Time.time;
    }

    public void apply_shader_with_args(float ontime,float size){
        shader_ontime=ontime;
        transparency_size=size;
        som_time=Time.time;
    }

}
