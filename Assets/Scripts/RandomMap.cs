using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] maps;
    void Start()
    {
        int randomMap = Random.Range(0, 5);
        maps[randomMap].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
