using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChange : MonoBehaviour
{
    [SerializeField] private GameObject targetCamera;
    public enum Direction {Right , Left}
    [SerializeField] private Direction chosenDirection;
    private CircleCollider2D CircleCollider2D;
    private SpriteRenderer SpriteRenderer;
    [SerializeField] Sprite[] Sprites;

    private Animator Animator;
    void Start()
    {
        CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Animator = targetCamera.GetComponent<Animator>();
        if(chosenDirection == Direction.Right)
        {
            SpriteRenderer.sprite = Sprites[0];
        }
        if(chosenDirection == Direction.Left)
        {
            SpriteRenderer.sprite = Sprites[1];
        }
    }
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
                Animator.SetTrigger("RotateRight");
            }
            if(chosenDirection == Direction.Left)
            {
                Animator.SetTrigger("RotateLeft");
            }
        }
    }
    void Idel()
    {
        Animator.SetTrigger("Idel");
    }
}
