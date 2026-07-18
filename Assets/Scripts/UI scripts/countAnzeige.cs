using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class countAnzeige : MonoBehaviour
{
    public Slider slidertimer1; 

    public void SetzeMaxLeben(int leben){
        slidertimer1.maxValue = leben;
        slidertimer1.value = leben;
    }

    public void SetzeLeben(int leben){
        slidertimer1.value = leben;
    }
}
