using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneController : MonoBehaviour
{
    [SerializeField] 
    private GameObject exitButton; 
    [SerializeField] 
    private GameObject finalVideo; 

    [SerializeField] 
    private UIHandler handler; 
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
           chatHolder.GetChild(currentChatEvent).gameObject.SetActive(false);
        
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
