using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    private Vector3 movePosition; //Die Position an die der Spieler sich bewegen möchte
    
    private int inputX;
    private int inputY;
    //private int moveBufferX;
    //private int moveBufferY;
    
    private bool enabledInput = true;
    
    [SerializeField] private float speed;
    [SerializeField] private int isPlayer; //Which Player...
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private int steps;
    [SerializeField] private Animator anim;
    
    public Transform spawnPoint;
    public bool isMoving = false;

    
    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
        else
        {
            Debug.Log("Spawn Point is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == 0)
            return;
        
        //Input
        inputX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal" + isPlayer));
        inputY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical" + isPlayer));
        
        //Bewegung mit Geschwindigkeit
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);
            if (transform.position == movePosition)
            {
                isMoving = false;
            }
        }
        
        //Hier wird geprüft ob runter gedrückt wurde...
        if (isMoving)
        {
            return;
        }
        else
        {
            if (enabledInput && (inputX !=0 || inputY !=0) && (inputX != 0 || inputY != 0))
            {
                movePosition = new Vector3(transform.position.x + inputX, transform.position.y + inputY, 0);
                if (CanMove(movePosition, new Vector3(inputX, inputY, 0)))
                {
                    isMoving = true;
                }
                enabledInput = false;
            }
            else if (inputX == 0 && inputY == 0)
            {
                enabledInput = true;
                
            }
        }

        AnimationForPlayer();

    }

    public bool CanMove(Vector3 pMovePosition, Vector3 pMoveDirection)
    {
        //Logik die prüft ob das Feld frei ist.
        for(int i = 1; i <= steps; i++)
        {
            Vector3 checkPos = transform.position + (pMoveDirection * i);

            Collider2D hit = Physics2D.OverlapCircle(checkPos, 0.2f, obstacleLayer);
            if (hit)
            {
                return false;
            }
            else
            {
                
            }
        }
        return true;
    }

    public void AnimationForPlayer()
    {
        if (isMoving)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
