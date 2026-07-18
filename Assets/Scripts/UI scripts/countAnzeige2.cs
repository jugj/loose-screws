using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countAnzeige : MonoBehaviour
{
    public Slider slidertimer2; 

    public void SetzeMaxZeit2(float zeit){
        slidertimer2.maxValue = zeit;
        slidertimer2.value = zeit;
    }

    public void SetzeZeit2(float zeit){
        slidertimer2.value = zeit;
    }
}
