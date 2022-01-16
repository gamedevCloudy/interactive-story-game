using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PasswordManager : MonoBehaviour
{
    [Header("Answer Text - UI")]
    [SerializeField]
    private GameObject wrongAnswer; 
    [SerializeField]
    private GameObject correctAns; 

    [Header("Answers")]
    public List<int> correctPattern; 
    public List<int> inputPattern; 
   
    [Header("Pattern Input Grids")]
    [SerializeField] 
    private GameObject[] patternInputGrids; 
    [SerializeField]
    private int currentPassId = 0; 

    
    public void VerifyPattern()
    {
        if(correctPattern[0] == inputPattern[0] )
        {
            if(correctPattern[1] == inputPattern[1])
            {
                if(correctPattern[2] == inputPattern[2])
                {
                   Debug.Log("Correct");
                   StartCoroutine(NextInputGrid()); 
                }
            }  
        }
        else if(correctPattern[0] == inputPattern[2])
        {
            if(correctPattern[1] == inputPattern[1])
            {
                if(correctPattern[2] == inputPattern[0])
                {
                    Debug.Log("Correct");
                    StartCoroutine(NextInputGrid()); 
                }
            }
        }
        else {
            StartCoroutine(WrongAns()); 
        }

    }

    IEnumerator NextInputGrid()
    {
        correctAns.SetActive(true); 
        yield return new WaitForSeconds(2); 
        correctAns.SetActive(false); 
        patternInputGrids[0].SetActive(false);

        if(currentPassId != 5)patternInputGrids[1].SetActive(true); 
        else { 
            Debug.Log(" Loading next scene!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        } 
    }

    IEnumerator WrongAns()
    {
        yield return new WaitForSeconds(1);
        wrongAnswer.SetActive(true); 
        yield return new WaitForSeconds(1); 
        wrongAnswer.SetActive(false); 
        
        inputPattern.Clear(); 
    }
}
