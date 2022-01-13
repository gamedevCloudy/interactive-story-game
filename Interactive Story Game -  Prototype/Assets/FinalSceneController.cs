using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneController : MonoBehaviour
{
    public GameObject exitButton; 
    public GameObject finalVideo; 

    public UIHandler handler; 
    [SerializeField] 
    private Transform chatHolder; 
    private int currentChatEvent = 0; 


  
    void Start()
    {
        chatHolder.GetChild(currentChatEvent).gameObject.SetActive(true); 
    }

    public void NextChat()
    {
        if(currentChatEvent < (chatHolder.childCount -1))
        {
            if(currentChatEvent < 0) currentChatEvent = 0;
            chatHolder.GetChild(currentChatEvent).gameObject.SetActive(false); 
            currentChatEvent += 1; 
            Debug.Log(currentChatEvent + " Chat");
            chatHolder.GetChild((currentChatEvent)).gameObject.SetActive(true);      
        }
        if(currentChatEvent >= 4)
        {
           // StartCoroutine("PuzzleState");
           chatHolder.GetChild(currentChatEvent).gameObject.SetActive(false);
           //DisableUI; 
           //Play Final video
            finalVideo.SetActive(true); 
            exitButton.SetActive(true); 
            handler.DisableUI(); 
        }
    }  
    public void PreviousChat()
    {
        if( currentChatEvent > 0)
        {
        chatHolder.GetChild(currentChatEvent).gameObject.SetActive(false);
        currentChatEvent -= 1; 
        Debug.Log(currentChatEvent + " Chat");
        chatHolder.GetChild((currentChatEvent)).gameObject.SetActive(true); 
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting"); 
        Application.Quit(); 
    }
}
