using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer10sec : MonoBehaviour
{
    public TextMeshProUGUI zahlerText;
    int maxZähler = 10;
    int zahler; 
    public Zeit1 zeit1;


    public void ButtonPressed(){
        zahler = zahler - 1;
        zahlerText.text = zahler + "";
        zeit1.SetzeLeben(zahler);
    }
    // Start is called before the first frame update
    void Start()
    {
        zahler = maxZähler;
        zeit1.SetzeMaxLeben(maxZähler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
