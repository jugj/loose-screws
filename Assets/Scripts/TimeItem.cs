using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TimeItem : MonoBehaviour
{
    // Start is called before the first frame update
    private bool collected;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask obstacleLayer;

    [SerializeField] private Tilemap tilemap;
	[SerializeField] private ParticleSystem destroyEffect;
	[SerializeField] private GameObject spriteRenderer;
	[SerializeField] private Collider2D collider;
	[SerializeField] private GameObject particle;
	private Vector3 boundsMirror;


    private int gridX;
    private int gridY;

    private Vector3 newPos;
    void Start()
    {
        Debug.Log(tilemap.cellBounds);
        BoundsInt bounds = tilemap.cellBounds;
		boundsMirror = new Vector3(bounds.min.x, bounds.max.y, 0f);
        gridX = bounds.position.x;
        gridY = bounds.position.y;
		Debug.Log(gridX);
		Debug.Log(gridY);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    void ChangeTime(GameObject player, float time)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("time");
        if (collision.gameObject.tag == "Player" && !collected)
        {
			destroyEffect.Play();
			//sound
            collected = true;
			spriteRenderer.SetActive(false);
			collider.enabled = false;
            ChangeTime(collision.gameObject, 3f);
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        float timer = 0.0f;
        float time = 1.5f;
        
        
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = FindNewRandomPos();
        collected = false;
		collider.enabled = true;
		spriteRenderer.SetActive(true);
    }

    Vector3 FindNewRandomPos()
    {
        Vector3 currentPos = transform.position;
		Debug.Log(gridX*2);
 
		while (!CanSpawn(newPos) || currentPos == newPos) 
		{
			float minX = Mathf.Min(boundsMirror.x, gridX);
			float maxX = Mathf.Max(boundsMirror.x, gridX);
			float minY = Mathf.Min(boundsMirror.y, gridY);
			float maxY = Mathf.Max(boundsMirror.y, gridY);

			float randomX = Random.Range(minX, maxX);
			float randomY = Random.Range(minY, maxY);
			float finalGridX = Mathf.Floor(randomX) + 0.5f;
			float finalGridY = Mathf.Floor(randomY) + 0.5f;
			newPos = new Vector3(finalGridX, finalGridY, 0f);
		}
        return newPos;


    }
    
    public bool CanSpawn(Vector3 pSpawnPosition)
    {
        //Logik die prüft ob das Feld frei ist.
        Vector3 checkPos = pSpawnPosition;

        Collider2D hit = Physics2D.OverlapCircle(checkPos, 0.2f, obstacleLayer);
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
    	
	void archiev() 
	{
      for(float i = 0.5f;i>gridX; i-=1f) 
			{
				for(float j = 0.5f;j>gridX; j-=1f) 
				{
					newPos = new Vector3(i, j, 0f);
					Instantiate(particle, newPos, Quaternion.identity);
				}
				
			}
	}
}
