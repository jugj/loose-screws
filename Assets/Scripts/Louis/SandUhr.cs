using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandUhr : MonoBehaviour
{
    [SerializeField]  GameObject targetTimer;
    public enum Time {EineSekunde , DreiSekunden};
    [SerializeField] private Time chosenTime;
    private CircleCollider2D CircleCollider2D;
    private SpriteRenderer SpriteRenderer;
    [SerializeField] Sprite[] Sprites;
    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(chosenTime == Time.EineSekunde)
        {
            SpriteRenderer.sprite = Sprites[0];
        }
        if(chosenTime == Time.DreiSekunden)
        {
            SpriteRenderer.sprite = Sprites[1];
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if  (other.CompareTag("Player"))
        {
            CircleCollider2D.enabled = false;
            SpriteRenderer.enabled = false;
            if(chosenTime == Time.EineSekunde)
            {
                
            }
            if(chosenTime == Time.DreiSekunden)
            {

            }
        }
    }
}
