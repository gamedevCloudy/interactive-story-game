using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipController : MonoBehaviour
{
    public GameObject clipA;
    public GameObject clipB; 

    float startTimer; 
    int rand = 0; 
    
    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime; 

        if(startTimer > 30 && rand == 0 )
        {
            Debug.Log("Stella ka hila");
            clipB.SetActive(true); 
            clipA.SetActive(false); 
            rand += 1; 
        }
    }
}
