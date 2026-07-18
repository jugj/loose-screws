using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    [SerializeField]
    float y_spawn_pos = -12f;
    [SerializeField]
    float x_spawn_pos = 0f;
    [SerializeField]
    GameObject spieler_active;
    [SerializeField]
    GameObject spielermodell;

    void Spawn(){
        Vector2 spawnpoint = new Vector2(x_spawn_pos, y_spawn_pos);
        spieler_active = Instantiate(spielermodell, spawnpoint, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
