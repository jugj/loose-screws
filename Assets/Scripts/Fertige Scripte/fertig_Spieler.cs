using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fertig_Spieler : MonoBehaviour
{
    
    public float Geschwindigkeit = 3f;
    public float Sprungkraft = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector2.up * Sprungkraft * Time.deltaTime, Space.World);
        }


        if (Input.GetKey("right"))
        {
            transform.Translate(Vector2.right * Geschwindigkeit * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("left"))
        {
            transform.Translate(Vector2.left * Geschwindigkeit * Time.deltaTime, Space.World);
        }
    }


}