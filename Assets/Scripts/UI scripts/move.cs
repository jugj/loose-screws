using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonDisapeared : MonoBehaviour
{

public Button Startbutton;

private void disablebutton(){
        Startbutton.gameObject.SetActive(false);
    }

    
}
