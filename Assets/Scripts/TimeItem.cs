using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TimeItem : MonoBehaviour
{
    // Start is called before the first frame update
    private bool collected;
    public AudioSource collect;
    [SerializeField] private Animator anim;
    [SerializeField] private Tilemap tilemap;
	[SerializeField] private ParticleSystem destroyEffect;
	[SerializeField] private GameObject spriteRenderer;
	[SerializeField] private Collider2D collider;
	[SerializeField] private GameObject particle;
	[SerializeField] private LayerMask obstacleLayer;
	private Vector3 boundsMirror;
	public int maxItemsToSpawn = 10;
    public int minX = -10, maxX = 10;
    public int minY = -5, maxY = 5;


    private int gridX;
    private int gridY;

    private Vector3 newPos;
    void Start()
    {
		SpawnRandomItems();
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    void ChangeTime(GridBasedMovement player, float time)
    {
		if(player.isPlayer == 1) 
		{
			player.timer.zahler += time;
		}
		else if  (player.isPlayer == 2) 
		{
			player.timer2.zahler2 += time;
		}
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("time");
        if (collision.gameObject.tag == "Player" && !collected)
        {
			destroyEffect.Play();
			collect.Play();
            collected = true;
			spriteRenderer.SetActive(false);
			collider.enabled = false;
            ChangeTime(collision.gameObject.GetComponent<GridBasedMovement>(), 3f);
            StartCoroutine(Respawn());
			
        }
    }

	void SpawnRandomItems()
    {
     	int randomX = Random.Range(minX, maxX + 1);             
        int randomY = Random.Range(minY, maxY + 1);             
        Vector3Int randomGridPos = new Vector3Int(randomX, randomY, 0);

        Vector3 worldCheckPos = tilemap.CellToWorld(randomGridPos) + tilemap.tileAnchor;

        int safetyNet = 0;

        while (!CanSpawn(worldCheckPos) && safetyNet < 1000)         
        {              
            randomX = Random.Range(minX, maxX + 1);             
            randomY = Random.Range(minY, maxY + 1);             
            randomGridPos = new Vector3Int(randomX, randomY, 0);              
            
            worldCheckPos = tilemap.CellToWorld(randomGridPos) + tilemap.tileAnchor;
            
            safetyNet++;         
        }

        if (CanSpawn(worldCheckPos))
        {
            transform.position = worldCheckPos;
            collected = false;
            collider.enabled = true;
            spriteRenderer.SetActive(true);
        }
        else 
        {
            Debug.LogWarning("Could not find a free spot after 1000 tries!");
        }
}

 	public void SpawnItemAtGrid(Vector3Int gridPosition)
    {
        Vector3 worldPos = tilemap.CellToWorld(gridPosition) + tilemap.tileAnchor;
        transform.position = worldPos;
		collected = false;
		collider.enabled = true;
		spriteRenderer.SetActive(true);
    }

    IEnumerator Respawn()
    {
        float timer = 0.0f;
        float time = 1.0f;
        
        
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
 		SpawnRandomItems();
        
    }

	public bool CanSpawn(Vector3 pSpawnPosition)
    {
        //Logik die prüft ob das Feld frei ist.
        Vector3 checkPos = pSpawnPosition;

        Collider2D hit = Physics2D.OverlapCircle(checkPos, 0.4f, obstacleLayer);
        if (hit)
        {
            Debug.Log("ok");
            return false;
        }
        else
        {
                
        }
        return true;
    }
    	
	
}
