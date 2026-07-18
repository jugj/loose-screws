using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countAnzeige : MonoBehaviour
{
    public Slider slidertimer1; 

    public void SetzeMaxZeit(float zeit){
        slidertimer1.maxValue = zeit;
        slidertimer1.value = zeit;
    }

    public void SetzeZeit(float zeit){
        slidertimer1.value = zeit;
    }
}
