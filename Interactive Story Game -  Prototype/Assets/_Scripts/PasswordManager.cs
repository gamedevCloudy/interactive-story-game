using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PasswordManager : MonoBehaviour
{
    public List<int> correctPattern; 
    public List<int> inputPattern; 
    // Start is called before the first frame update
    [SerializeField] 
    private GameObject[] patternGrids; 
    [SerializeField]
    private int currentPassId = 0; 

    public GameObject wrongAnswer; 
    public GameObject correctAns; 

    public void VerifyPattern()
    {
        if(correctPattern[0] == inputPattern[0] )
        {
            if(correctPattern[1] == inputPattern[1])
            {
                if(correctPattern[2] == inputPattern[2])
                {
                   // return true; 
                   Debug.Log("Correct");
                   StartCoroutine(NextGridLock()); 
                }
            }  
        }
        else if(correctPattern[0] == inputPattern[2])
        {
            if(correctPattern[1] == inputPattern[1])
            {
                if(correctPattern[2] == inputPattern[0])
                {
                    //return true; 
                    Debug.Log("Correct");
                    StartCoroutine(NextGridLock()); 
                }
            }
        }
        else {
            StartCoroutine(WrongAns()); 
        }

    }

    IEnumerator NextGridLock()
    {
        correctAns.SetActive(true); 
        yield return new WaitForSeconds(2); 
        correctAns.SetActive(false); 
        //Load Next Pattern
        patternGrids[0].SetActive(false);
        //currentPassGrid +=1; 
        if(currentPassId != 5)patternGrids[1].SetActive(true); 
        else { 
            // load next scnene
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
