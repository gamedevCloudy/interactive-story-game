using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordController : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] patternInputGrid; 
    [SerializeField]
    private int currentPatternInputGrid; 

    void Start()
    {
        currentPatternInputGrid = 0; 
    }

    public void NextLock()
    {
        patternInputGrid[currentPatternInputGrid].SetActive(false);
        currentPatternInputGrid +=1; 
        patternInputGrid[currentPatternInputGrid].SetActive(true);  

    }
}
