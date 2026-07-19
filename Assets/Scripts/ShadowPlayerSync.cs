using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShadowPlayerSync : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap1;
    [SerializeField] private Tilemap tilemap2;

    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    [SerializeField] private Transform shadowMap1;
    [SerializeField] private Transform shadowMap2;

    [SerializeField] private GameObject shadowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g1 = Instantiate(shadowPrefab);
        shadowMap1 = g1.transform;
        
        GameObject g2 = Instantiate(shadowPrefab);
        shadowMap2 = g2.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && shadowMap2 != null)
        {
            Vector3Int gridPos1 = tilemap1.WorldToCell(player1.position);
            
            Vector3 targetWorldPos2 = tilemap2.CellToWorld(gridPos1) + tilemap2.tileAnchor;
            
            shadowMap2.position = targetWorldPos2;
        }

        if (player2 != null && shadowMap1 != null)
        {
            Vector3Int gridPos2 = tilemap2.WorldToCell(player2.position);
            
            Vector3 targetWorldPos1 = tilemap1.CellToWorld(gridPos2) + tilemap1.tileAnchor;
            
            shadowMap1.position = targetWorldPos1;
        }
    }
}
