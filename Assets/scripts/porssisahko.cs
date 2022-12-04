using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class porssisahko : MonoBehaviour

{
    public TMP_Text aika2;
    public float hinta = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Hinta päivittyy joka frame vai olisiko parempi jos se päivittyy aina silloin kun taski on tehty?
        // Tällöin siirrä funktion kutsu Updaten sijaan -> task_list_script.cs update_cost_index -funktioon!
        ElectrcityPrice();
    }

    public void ElectrcityPrice()
    {
        string tunti = aika2.text;
        
        // Sähkön hinta tunneittain euroina 3.12.2022
        switch (tunti)
        {
            case "7:00":
                hinta = 0.3013f;
                break;
            case "8:00":
                hinta = 0.33f;
                break;
            case "9:00":
                hinta = 0.341f;
                break;
            case "10:00":
                hinta = 0.33f;
                break;
            case "11:00":
                hinta = 0.3629f;
                break;
            case "12:00":
                hinta = 0.363f;
                break;
            case "13:00":
                hinta = 0.363f;
                break;
            case "14:00":
                hinta = 0.3701f;
                break;
            case "15:00":
                hinta = 0.4279f;
                break;
            case "16:00":
                hinta = 0.4391f;
                break;
            case "17:00":
                hinta = 0.495f;
                break;
            case "18:00":
                hinta = 0.4391f;
                break;
            case "19:00":
                hinta = 0.4495f;
                break;
            case "20:00":
                hinta = 0.3964f;
                break;
            case "21:00":
                hinta = 0.3856f;
                break;

        }

    }
}
