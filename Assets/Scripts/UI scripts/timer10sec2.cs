using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer10sec2 : MonoBehaviour
{
    public TextMeshProUGUI zahlerText2;
    public float maxZähler2 = 10;
    public float zahler2; 
    public bool button_pressed2 = false;
    public countAnzeige2 count2;
    public buttonrealypressed b1;
    public bool button_pressedR = false;
    


    public void ButtonPressed(){
        if (button_pressedR == true) {
        button_pressed2 = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        zahler2 = maxZähler2;
        count2.SetzeMaxZeit2(maxZähler2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(zahler2 <= 0)) {
            if (button_pressed2 == true){
            zahler2 = zahler2 - Time.deltaTime; 
            
            }
        }
        else 
        {zahler2 = 0;}
        zahlerText2.text =  Mathf.Round(zahler2) + "";
        count2.SetzeZeit2(zahler2);
    }
}
