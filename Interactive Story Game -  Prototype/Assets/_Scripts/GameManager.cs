using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 

public class GameManager : MonoBehaviour
{
    private enum State{
        Intro, First_Talk, Puzzle, Last_Talk, Final
    }
    State state;
    
    [SerializeField]
    private ChatEventController chatSys; 
    [SerializeField]
    private ChatEventController chatSys1; 
    [SerializeField]
    private GameObject chatButtons; 
    [SerializeField]
    private GameObject chatButtons1; 
    public GameObject pause; 
    [SerializeField]
    private GameObject[] clips; 

    public GameObject puzzle; 
    
    float timeSinceStart = 0; 

    int chatCtrl = 0; 


    private void Start()
    {
        state = State.Intro; 
    }
    private void Update()
    {
        StateHandler(); 
        //Debug.Log(timeSinceStart); 
        timeSinceStart += Time.deltaTime; 
        //StateHandler(state);
        if(timeSinceStart >= 20)
        {
            state = State.First_Talk; 
        }
    }

    void StateHandler()
    {
       switch (state)
       {
            default:
            case State.Intro: 
                //playfirstclip
                Debug.Log(state); 
                break;  
            case State.First_Talk: 
                //enable chat system 
                clips[1].SetActive(true);
                clips[0].SetActive(false);  
                Debug.Log(state); 
                //enable chat system
                chatSys.enabled = true; 
                if(chatCtrl == 0)
                {
                    pause.SetActive(true); 
                    chatButtons.SetActive(true); 
                    chatCtrl +=1; 
                }
                break; 
            case State.Puzzle: 
                //play the puzzle 
                Debug.Log(state); 
            
                // clips[2].SetActive(true);
                // clips[1].SetActive(false);  
                puzzle.SetActive(true); 
                break; 
            case State.Final:
                //play last clip 
                
                puzzle.SetActive(false); 
                clips[3].SetActive(true);
                clips[2].SetActive(false);   
                chatSys1.enabled = true; 
                chatButtons1.SetActive(true); 
                  //  chatCtrl +=1; 
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
