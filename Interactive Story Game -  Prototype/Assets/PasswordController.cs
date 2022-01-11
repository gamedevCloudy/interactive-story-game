using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordController : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] patternGrids; 
    [SerializeField]
    private int currentPassGrid; 

    // Start is called before the first frame update
    void Start()
    {
        currentPassGrid = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLock()
    {
        patternGrids[currentPassGrid].SetActive(false);
        currentPassGrid +=1; 
        patternGrids[currentPassGrid].SetActive(true);  

    }
}
