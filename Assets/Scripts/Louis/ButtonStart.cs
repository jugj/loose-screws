using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void pressed()
    {
        anim.SetTrigger("Pressed");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
