using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steinschlag : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {   
        //zerstöre den Stein.
        Destroy(gameObject);
    }
}
