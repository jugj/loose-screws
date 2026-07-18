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


    private int gridX;
    private int gridY;

    private Vector3 newPos;
    void Start()
    {
        Debug.Log(tilemap.cellBounds);
        BoundsInt bounds = tilemap.cellBounds;
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
        while (!CanSpawn(newPos) || currentPos == newPos || newPos == Vector3.zero)
        {
           Debug.Log(newPos);
           int x = Random.Range(-gridX, gridX);
           int y = Random.Range(-gridY, gridY);
           newPos = new Vector3(x+0.5f, y+0.5f, 0f);
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
    
}
