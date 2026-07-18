using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lebensAnzeige : MonoBehaviour
{
    public Slider sliderLeben; 

    public void SetzeMaxLeben(int leben){
        sliderLeben.maxValue = leben;
        sliderLeben.value = leben;
    }

    public void SetzeLeben(int leben){
        sliderLeben.value = leben;
    }
}
