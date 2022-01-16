using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    private enum State{
        Intro, First_Talk, Puzzle,
    }
    private State state;
    
    [SerializeField]
    private GameObject[] reactionClip; 
    float timeSinceStart = 0; 

    [SerializeField]
    private ChatEventController chatController; 
   
    [SerializeField]
    private GameObject chatButtons; 
    int chatCtrl = 0; 

    [Header("UI Objects")]
    public GameObject pause; 
    public GameObject puzzle; 
   
    private void Start()
    {
        state = State.Intro; 
    }
    
    private void Update()
    {
        StateHandler(); 
        timeSinceStart += Time.deltaTime; 
        if(timeSinceStart >= 20)
        {
            state = State.First_Talk; 
        }
    }

    void StateHandler()
    {
       switch (state)
       {
            case State.Intro: 
            Debug.Log(state); 
            break;  

            case State.First_Talk: 

            reactionClip[1].SetActive(true); //Breathing Animation
            reactionClip[0].SetActive(false);  
            Debug.Log(state); 
            
            chatController.enabled = true; 
            if(chatCtrl == 0)
            {
                pause.SetActive(true); 
                chatButtons.SetActive(true); 
                chatCtrl +=1; 
            }
            break; 

            case State.Puzzle: 
            Debug.Log(state); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            break; 
            
            default:
            break; 

       } 
    }

    public void SetPuzzle()
    {
        chatButtons.SetActive(false); 
        state = State.Puzzle; 
    }
}
