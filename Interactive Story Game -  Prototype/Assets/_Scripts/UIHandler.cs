using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject play; 
    public GameObject pause; 

    public GameObject controls;
    public GameObject controls2; 
    public GameObject darkScreen;

    private bool gameIsPaused; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        pause.SetActive(false);
        controls.SetActive(false); 
        play.SetActive(true); 
        darkScreen.SetActive(true); 
        //Time.timeScale = 0.0f; 
        gameIsPaused = true; 
    }
     public void PlayGame()
    {
        play.SetActive(false); 
        pause.SetActive(true);
        controls.SetActive(true); 
        darkScreen.SetActive(false); 
        //Time.timeScale = 1.0f; 
        gameIsPaused = false; 
    }
}
