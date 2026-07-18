using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandUhr : MonoBehaviour
{
    [SerializeField] private GameObject targetTimer;
    public enum Timers {Right , Left}
    [SerializeField] private Timers chosenTimer;
    public enum Time {1Sekund , 3Sekunden};
    [SerializeField] private Time chosenTime;
    private CircleCollider2D CircleCollider2D;
    private SpriteRenderer SpriteRenderer;
    [SerializeField] Sprite[] Sprites;
    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(chosenTime == Time.1Sekunde)
        {
            SpriteRenderer.sprite = Sprites[0];
        }
        if(chosenDirection == Timers.Left)
        {
            SpriteRenderer.sprite = Sprites[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Rotate");
        if  (other.CompareTag("Player"))
        {
            CircleCollider2D.enabled = false;
            SpriteRenderer.enabled = false;
            if(chosenDirection == Direction.Right)
            {
            }
            if(chosenDirection == Direction.Left)
            {
            }
        }
    }
}
