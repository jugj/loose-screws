using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public AudioSource death;
    public GridBasedMovement[] playerNumbers;
    public int winner;
	private string spielStatus;
    public GridBasedMovement player1;
    public GridBasedMovement player2;
	public GameObject winPanel;

    public static GameManager Instance { get;private set; }
    public TextMeshProUGUI myTextObject; 
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(player1.timer.zahler <= 0 && player2.timer2.zahler2 != player1.timer.zahler)
		{
        death.Play();
        myTextObject.text = "Player 2 Won!";
		winPanel.SetActive(true);
player1.timer.stop = true;
player2.timer2.stop = true;
//2 gewonnen
		}
else if(player2.timer2.zahler2 <= 0 && player2.timer2.zahler2 != player1.timer.zahler) 
		{
//1 gewonnen
        death.Play();
        myTextObject.text = "Player 1 Won!";
		winPanel.SetActive(true);
player2.timer2.stop = true;
player1.timer.stop = true;
}
else if(player2.timer2.zahler2 == player1.timer.zahler && player1.timer.zahler <= 0 && player2.timer2.zahler2 <= 0 ) 
{
myTextObject.text = "Draw";
winPanel.SetActive(true);
player2.timer2.stop = true;
player1.timer.stop = true;
}
    }

public void menu() 
{
 SceneManager.LoadScene("Start");
}
}
