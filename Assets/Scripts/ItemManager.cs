using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemManager : MonoBehaviour
{
    public Tilemap tilemap1;
    public Tilemap tilemap2;

    public GameObject itemPrefab;
    
    private Dictionary<Vector3Int, GameObject[]> spawnedItems = new Dictionary<Vector3Int, GameObject[]>();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnItemAtGrid(Vector3Int gridPosition)
    {
        if (spawnedItems.ContainsKey(gridPosition)) return;

        Vector3 worldPos1 = tilemap1.CellToWorld(gridPosition) + tilemap1.tileAnchor;
        Vector3 worldPos2 = tilemap2.CellToWorld(gridPosition) + tilemap2.tileAnchor;

        GameObject item1 = Instantiate(itemPrefab, worldPos1, Quaternion.identity);
        GameObject item2 = Instantiate(itemPrefab, worldPos2, Quaternion.identity);

        spawnedItems[gridPosition] = new GameObject[] { item1, item2 };
    }
    public void DespawnItemAtGrid(Vector3Int gridPosition)
    {
        if (spawnedItems.ContainsKey(gridPosition))
        {
            Destroy(spawnedItems[gridPosition][0]);
            Destroy(spawnedItems[gridPosition][1]);

            spawnedItems.Remove(gridPosition);
        }
    }
}
