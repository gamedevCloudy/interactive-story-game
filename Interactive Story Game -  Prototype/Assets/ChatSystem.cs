using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    private enum ChatState{ //each chat state denotes one character/talk from the player and its response
        cs01,
        cs02,
        cs03,
        cs04, 
    }

    private ChatState currentState; 
    private int currentStateInt; 

    [SerializeField] 
    private GameObject[] cs01_Png; 
    [SerializeField] 
    private GameObject[] cs02_Png; 
    [SerializeField] 
    private GameObject[] cs03_Png; 
    [SerializeField] 
    private GameObject[] cs04_Png; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChatContoller();     
        if(Input.GetKeyDown(KeyCode.Space)) currentState = ChatState.cs02; 
    }

    private void ChatContoller()
    {
        //switch among chat states - display png after timers. 
        switch (currentState)
        {
            default:
            case ChatState.cs01: 
            float timer = 1; 
            Debug.Log(timer); 
            timer -= Time.deltaTime;
             Debug.Log(timer);  
            cs01_Png[0].SetActive(true); 
            if(timer < 0) cs01_Png[1].SetActive(true); 
            break; 

            case ChatState.cs02:
            timer = 1; 
            timer -= Time.deltaTime; 


            cs02_Png[0].SetActive(true); 
            if(timer < 0) cs02_Png[1].SetActive(true); 
            break; 

            case ChatState.cs03: 
            break; 
            case ChatState.cs04: 
            break; 
        }
    }

}
