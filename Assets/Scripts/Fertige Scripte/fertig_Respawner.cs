using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fertig_Respawner : MonoBehaviour
{
    [SerializeField]
    GameObject spieler_prefab;

    [SerializeField]
    GameObject spieler_active;


    // f steht für float
    [SerializeField]
    float y_spawn_pos = 1f;
    [SerializeField]
    float x_spawn_pos = -8f;


    void SpawnSpieler()
    {
        Vector2 position = new Vector2(x_spawn_pos, y_spawn_pos);
        spieler_active = Instantiate(spieler_prefab, position, Quaternion.identity);
    }



    // Start is called before the first frame update
    void Start()
    {
        SpawnSpieler();
    }

    // Update is called once per frame
    void Update()
    {
        if (spieler_active == null) {
            SpawnSpieler();
        }

    }
}
