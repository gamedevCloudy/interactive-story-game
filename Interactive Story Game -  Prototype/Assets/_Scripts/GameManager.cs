using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    private enum State{
        Intro, First_Talk, Puzzle, Last_Talk, Final
    }
    State state;
    [SerializeField]
    private GameObject[] clips; 
    float timeSinceStart = 0; 

    [Header("Chat Events Objects")]
    [SerializeField]
    private ChatEventController chatSys; 
    [SerializeField]
    private ChatEventController chatSys1; 

    [SerializeField]
    private GameObject chatButtons; 
    int chatCtrl = 0; 
    [SerializeField]
    private GameObject chatButtons1; 
    int chat2Ctrl = 0; 

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

            clips[1].SetActive(true); //Breathing Animation
            clips[0].SetActive(false);  
            Debug.Log(state); 
            
            chatSys.enabled = true; 
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


            case State.Last_Talk:
            puzzle.SetActive(false); //Disable Previous State
            clips[5].SetActive(true);
            clips[4].SetActive(false);   
            chatSys1.enabled = true; 
            if(chat2Ctrl == 0)
            {
                pause.SetActive(true); 
                chatButtons1.SetActive(true); 
                chat2Ctrl += 1; 
            }
            chatButtons1.SetActive(true); 
            break;  

            case State.Final: 
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

    public void Finale()
    {
        state = State.Final; 
    }
}
