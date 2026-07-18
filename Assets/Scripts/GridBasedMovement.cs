using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    private Vector2 movePosition; //Die Position an die der Spieler sich bewegen möchte
    
    private int inputX;
    private int inputY;

    private bool enabledInput = true;

    [SerializeField] private float speed;
    [SerializeField] private int isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == 0)
        {
            return;
        }
        
        //Input
        inputX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        inputY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        
        //Hier wird geprüft ob runter gedrückt wurde.
        if (enabledInput && (inputX !=0 || inputY !=0))
        {
            movePosition = new Vector2(transform.position.x + inputX, transform.position.y + inputY);
            if (CanMove(movePosition))
            {
                transform.position = Vector2.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);
            }
            enabledInput = false;
        }
        else if (inputX == 0 && inputY == 0)
        {
            enabledInput = true;
        }



    }

    bool CanMove(Vector2 pMovePosition)
    {
        //Logik die prüft ob das Feld frei ist.
        return true;
    }
}
