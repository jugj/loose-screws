using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer10sec : MonoBehaviour
{
    public TextMeshProUGUI zahlerText;
    public float maxZähler = 10;
    public float zahler; 
    public bool button_pressed = false;
    public countAnzeige count1;
    


    public void ButtonPressed(){
        button_pressed = true;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        zahler = maxZähler;
        count1.SetzeMaxZeit(maxZähler);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(zahler <= 0)) {
            if (button_pressed == true){
            zahler = zahler - Time.deltaTime; 
            
            }
        }
        else 
        {zahler = 0;}
        zahlerText.text =  Mathf.Round(zahler) + "";
        count1.SetzeZeit(zahler);
    }
}
