using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    public enum ChatState{ //each chat state denotes one character/talk from the player and its response
        cs01,
        cs02,
        cs03,
        cs04, 
    }
    public ChatState currentState; 
    private int currentStateInt; 

    [Header("Chat Conatianer")]
    [SerializeField]
    private Transform chatS01; 
    [SerializeField]
    private Transform chatS02; 
    [SerializeField]
    private Transform chatS03; 
    [SerializeField]
    private Transform chatS04; 

    [Header("Random Vars")]
    private int dis = 0;
    private int dis1 = 0;
    private int dis2 = 0;   
    private int dis3 = 0; 
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
            currentStateInt = 1; 
            chatS01.gameObject.SetActive(true); 
            StartCoroutine("Chat1"); 
            break; 

            case ChatState.cs02:
            currentStateInt = 2; 
            chatS02.gameObject.SetActive(true); 
            StartCoroutine("Chat2"); 
            StopCoroutine("Chat1"); 
            break; 

            case ChatState.cs03: 
            currentStateInt = 3; 
            chatS03.gameObject.SetActive(true); 
            StartCoroutine("Chat3"); 
            StopCoroutine("Chat2"); 
            break; 

            case ChatState.cs04:
            currentStateInt = 4;  
            chatS04.gameObject.SetActive(true); 
            StartCoroutine("Chat4"); 
            StopCoroutine("Chat3"); 
            break; 
        }
    }

    IEnumerator Chat1()
    {
        
        yield return new WaitForSeconds(0.25f); 
        //cs01_Png[0].SetActive(true); 
        if(dis < 1) chatS01.GetChild(0).gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f); 
        chatS01.GetChild(0).gameObject.SetActive(false); 
        dis += 1; 
        chatS01.GetChild(1).gameObject.SetActive(true); 
    }
    IEnumerator Chat2()
    {
        chatS01.gameObject.SetActive(false); 
        yield return new WaitForSeconds(0.25f); 
        if(dis1 < 1) chatS02.GetChild(0).gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f); 
        chatS02.GetChild(0).gameObject.SetActive(false); 
        dis1 += 1; 
        chatS02.GetChild(1).gameObject.SetActive(true); 
    }
    IEnumerator Chat3()
    {
        chatS02.gameObject.SetActive(false); 
        yield return new WaitForSeconds(0.25f); 
        if(dis2 < 1) chatS03.GetChild(0).gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f); 
        chatS03.GetChild(0).gameObject.SetActive(false); 
        dis2 += 1; 
        chatS03.GetChild(1).gameObject.SetActive(true); 
    }
    IEnumerator Chat4()
    {
        chatS03.gameObject.SetActive(false); 
        yield return new WaitForSeconds(0.25f); 
        if(dis3 < 1) chatS04.GetChild(0).gameObject.SetActive(true); 
        yield return new WaitForSeconds(1f); 
        chatS04.GetChild(0).gameObject.SetActive(false); 
        dis3 += 1; 
        chatS04.GetChild(1).gameObject.SetActive(true); 
    }


    public void NextState()
    {
        if(currentStateInt == 1) currentState = ChatState.cs02; 
        if(currentStateInt == 2) currentState = ChatState.cs03; 
        if(currentStateInt == 3) currentState = ChatState.cs04;
        if(currentStateInt == 4) currentState = ChatState.cs04; /// switch to puzzle
    }
    public void PreviousState()
    {
        dis = 0; 
        dis1 = 0; 
        dis2 = 0; 
        dis3 = 0; 
        if(currentStateInt == 1) {
            currentState = ChatState.cs01;
        }
        if(currentStateInt == 2) {
            currentState = ChatState.cs01;
            chatS02.gameObject.SetActive(false); 
            for(int i =0; i < chatS02.childCount; i++)
            {
                chatS02.GetChild(i).gameObject.SetActive(false); 
            }
        }
        if(currentStateInt == 3) {
            currentState = ChatState.cs02;
            chatS03.gameObject.SetActive(false);
            for(int i =0; i < chatS03.childCount; i++)
            {
                chatS03.GetChild(i).gameObject.SetActive(false); 
            }
        }
        if(currentStateInt == 4) {
            currentState = ChatState.cs03;
            chatS04.gameObject.SetActive(false);
            for(int i =0; i < chatS04.childCount; i++)
            {
                chatS04.GetChild(i).gameObject.SetActive(false); 
            }
        }
    }
}
