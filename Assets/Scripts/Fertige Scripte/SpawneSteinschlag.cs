using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneSteinschlag : MonoBehaviour
{

    [SerializeField] GameObject steinschlag_prefab;


    void SpawnSteinschlag()
    {   //erstelle einen Stein an einer zufälligen Position zwischen 8 Einheiten links und 8 Einheiten rechts vom zentrum des Bildes
        float y_pos = 13f;                      // Das Sichtfeld geht ca. 12 Einheiten nach oben. Wir wollen den Stein eine Einheit über dem Sichtfeld spawnen
        float x_pos = Random.Range(-8f, 8f);    // eine zufällige Zahl zwischen -8 und 8 
        Vector2 position = new Vector2(x_pos, y_pos); //Wandle die Zahlen in eine Position um

        // Erstelle den Stein an der position.
        GameObject steinschlag_active = Instantiate(steinschlag_prefab, position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {   
        //starte den Steinschlag
        StartCoroutine(starteSteinschlag());
    }

    IEnumerator starteSteinschlag()
    {
        //Für immer: Spawne einen Stein, dann warte 2 Sekunden.
        while (true)
        {
            SpawnSteinschlag();
            yield return new WaitForSeconds(2f);
        }
    }
}
