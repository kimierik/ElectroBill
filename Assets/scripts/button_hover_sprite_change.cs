using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class button_hover_sprite_change : MonoBehaviour //IPointerExitHandler, IPointerEnterHandler
{

    Texture2D normal;    
    Texture2D onhover;
    Sprite onhover_sprite;
    Sprite normal_sprite;
    Button option2;
    Button option1;


    void Start()
    {
       normal = Resources.Load<Texture2D>("nappi");
       onhover = Resources.Load<Texture2D>("nappi-aktivoitu");

       option2=GameObject.Find("option2").GetComponent<Button>();
       option1=GameObject.Find("option1").GetComponent<Button>();

       onhover_sprite=Sprite.Create(onhover,new Rect(0,0,onhover.width,onhover.height) ,new Vector3(1f,1f,1f),100f);
       normal_sprite=Sprite.Create(normal,new Rect(0,0,normal.width,normal.height) ,new Vector3(1f,1f,1f),100f);

    }


    public void on_hover_op2(){
        option2.image.sprite=onhover_sprite;
    }

    public void on_hover_op1(){
        option1.image.sprite=onhover_sprite;
    }

    public void normalop2(){
        option2.image.sprite=normal_sprite;
    }

    public void normalop1(){
        option1.image.sprite=normal_sprite;
    }

}
