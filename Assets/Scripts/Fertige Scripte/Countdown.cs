using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countdown : MonoBehaviour
{
    [SerializeField] float startZahl = 10.0f;
    [SerializeField] float schritt = 1.0f;
    [SerializeField] float aktueller_wert = 1.0f;
    [SerializeField] TMP_Text textfeld = null;


    // Start is called before the first frame update
    void Start()
    {
        this.aktueller_wert = startZahl;
        StartCoroutine(starteCountdown());
    }


    // Starte Countdown
    IEnumerator starteCountdown()
    {
        while (aktueller_wert >= 0.0f)
        {
            // reduziere den aktuellen Wert um "schritt"
            this.aktueller_wert = this.aktueller_wert - schritt;

            // schreibe den aktuellen wert in den text der zum textfeld gehört.
            textfeld.text = "Countdown: " + this.aktueller_wert.ToString();

            // der Countdown ist fertig, aber 
            if (aktueller_wert < 0.0f)
            {
                textfeld.text = "Countdown ist fertig";
            }

            // warte für "schritt" sekunden
            yield return new WaitForSeconds(schritt);
        }
    }
}
