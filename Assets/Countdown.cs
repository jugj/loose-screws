using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{  float start = 10f;
  [SerializeField]float current;
  [SerializeField] public TextMeshProUGUI numbertext;
   

    // Start is called before the first frame update
    void Start()
    {
        current = start;
         UpdateTimerUI();
    
    }

    // Update is called once per frame
    void Update()
    { 
        current = current - Time.deltaTime;
        numbertext.text = current + "";
        

        if (current <= 0f)
        {
            // Aktion bei Null
            OnTimerFinished();

            // Timer zurücksetzen
            current = start;
    }

      UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        // Anzeige auf ganze Sekunden runden
        numbertext.text = Mathf.Ceil(current).ToString();
    }

    void OnTimerFinished()
    {
        // Hier kommt deine Aktion hin
        
    }
}
