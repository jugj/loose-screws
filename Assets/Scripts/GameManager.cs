using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridBasedMovement[] playerNumbers;
    public int winner;
	private string spielStatus;
    
    public static GameManager Instance { get;private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        //Sorgt dafür, dass der GameManager nicht beim Laden einer neuen Szene zerstört wird.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
