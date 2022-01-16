using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatEventController : MonoBehaviour
{
    [SerializeField]
    private GameManager manager; 
    [SerializeField] 
    private Transform chatContainer; 
    
    private int currentMessageIndex = 0; 
  
    void Start()
    {
        chatContainer.GetChild(currentMessageIndex).gameObject.SetActive(true); 
    }

    public void NextChat()
    {
        if(currentMessageIndex < (chatContainer.childCount -1))
        {
            if(currentMessageIndex < 0) currentMessageIndex = 0;
            chatContainer.GetChild(currentMessageIndex).gameObject.SetActive(false); 
            currentMessageIndex += 1; 
            Debug.Log(currentMessageIndex + " Chat");
            chatContainer.GetChild((currentMessageIndex)).gameObject.SetActive(true);      
        }
        if(currentMessageIndex >= 6)
        {
            StartCoroutine("PuzzleState"); 
        }
    }  
    public void PreviousChat()
    {
        if( currentMessageIndex > 0)
        {
        chatContainer.GetChild(currentMessageIndex).gameObject.SetActive(false);
        currentMessageIndex -= 1; 
        Debug.Log(currentMessageIndex + " Chat");
        chatContainer.GetChild((currentMessageIndex)).gameObject.SetActive(true); 
        }
    }

    IEnumerator PuzzleState()
    {
        yield return new WaitForSeconds(2); 
        chatContainer.gameObject.SetActive(false); 
        manager.SetPuzzle(); 
    }
}
