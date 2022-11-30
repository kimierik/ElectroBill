using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour {

    public GameObject player;
    public float transparency_size=0.2f;
    public float transparency_on_time=0.1f;
    public Material mat;
    public Material Defaulta_material;

    void Update()
    {
        apply_shader_with_ray(); 
    }

    void apply_shader_with_ray(){
        Vector3 cam_pos=transform.position;
        Vector3 player_pos=player.transform.position;

        cast_ray(new Ray(cam_pos,player_pos-cam_pos));
        cast_ray(new Ray(player_pos,cam_pos-player_pos));
    }

    void cast_ray(Ray ray){
        if(Physics.Raycast(ray, out RaycastHit hit ,100f)){
            Wall_transparency_script trg=hit.transform.GetComponent<Wall_transparency_script >();
            if(trg!=null){
                trg.set_materials(Defaulta_material,mat);
                trg.apply_shader_with_args(transparency_on_time,transparency_size);
            }
        }
    }

}
