using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChanger : MonoBehaviour
{   
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] PlayerSprites;

    public enum  Players {PlayerEins,PlayerZwei};
    [SerializeField] private Players chosenPlayer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlayerSprites[0];
    }
    void Update()
    {
        if(chosenPlayer == Players.PlayerEins)
        {
        if(Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = PlayerSprites[0];
        }  
        if(Input.GetKey(KeyCode.A))
        {   
            spriteRenderer.sprite = PlayerSprites[1];
        } 
        if(Input.GetKey(KeyCode.W))
        {  
            spriteRenderer.sprite = PlayerSprites[2];
        }
        if(Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = PlayerSprites[3];
        }
        }
        if(chosenPlayer == Players.PlayerZwei)
        {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = PlayerSprites[0];
        }  
        if(Input.GetKey(KeyCode.LeftArrow))
        {   
            spriteRenderer.sprite = PlayerSprites[1];
        } 
        if(Input.GetKey(KeyCode.UpArrow))
        {  
            spriteRenderer.sprite = PlayerSprites[2];
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = PlayerSprites[3];
        }
        }

    }
}
