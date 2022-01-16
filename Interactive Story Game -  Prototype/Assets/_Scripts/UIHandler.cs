using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private GameObject play; 
    [SerializeField]
    private GameObject pause; 
    [SerializeField]
    private GameObject controls;

    [SerializeField]
    private GameObject darkScreen;

    private bool gameIsPaused; 

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
        gameIsPaused = true; 
    }

    public void PlayGame()
    {
        play.SetActive(false); 
        pause.SetActive(true);
        controls.SetActive(true); 
        darkScreen.SetActive(false); 
        gameIsPaused = false; 
    }

    public void DisableUI()
    {
        play.SetActive(false); 
        controls.SetActive(false); 
        pause.SetActive(false); 
    }
}
