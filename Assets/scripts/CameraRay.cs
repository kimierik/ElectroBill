using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate(){
    } 



    // Update is called once per frame
    void Update()
    {

        Ray ray =new Ray(transform.position,transform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit ,100f)){
            Debug.DrawLine(transform.position,hit.point,Color.red,1f);

            Wall_transparency_script trg=hit.transform.GetComponent<Wall_transparency_script >();
            if(trg!=null){
                trg.apply_shader();
            }
        }


        
    }
}
