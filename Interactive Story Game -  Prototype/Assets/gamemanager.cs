using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 

public class gamemanager : MonoBehaviour
{
    public enum State{
        Intro, First_Talk, Puzzle, Final
    }
    State state; 
    
    public GameObject[] clips; 
    
    float timeSinceStart = 0; 


    private void Start()
    {
        state = State.Intro; 
    }
    private void Update()
    {
        StateHandler(); 
        Debug.Log(timeSinceStart); 
        timeSinceStart += Time.deltaTime; 
        //StateHandler(state);
        if(timeSinceStart >= 20)
        {
            state = State.First_Talk; 
        }
        if(timeSinceStart >= 25)
        {
            state = State.Puzzle; 
        }
        if(timeSinceStart >= 30)
        {
            state = State.Final; 
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
                break; 
            case State.Puzzle: 
                //play the puzzle 
                clips[2].SetActive(true);
                clips[1].SetActive(false);  
                break; 
            case State.Final:
                //play last clip 
                clips[3].SetActive(true);
                clips[2].SetActive(false);   
                break;  
       } 
    }
}
