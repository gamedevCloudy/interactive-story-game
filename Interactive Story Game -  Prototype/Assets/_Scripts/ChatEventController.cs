using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatEventController : MonoBehaviour
{
    [SerializeField]
    private GameManager manager; 
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
        if(currentChatEvent >= 6)
        {
            StartCoroutine("PuzzleState"); 
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

    IEnumerator PuzzleState()
    {
        yield return new WaitForSeconds(2); 
        chatHolder.gameObject.SetActive(false); 
        manager.SetPuzzle(); 
    }
}
