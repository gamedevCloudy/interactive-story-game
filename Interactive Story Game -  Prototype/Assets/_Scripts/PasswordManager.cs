using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    public List<int> correctPattern; 
    public List<int> inputPattern; 
    // Start is called before the first frame update
    void Start()
    {
        // correctPattern.Add(0);
        // correctPattern.Add(1); 
        // correctPattern.Add(2); 

        //correctPattern2.Add(0)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool VerifyPattern()
    {
        if(correctPattern[0] == inputPattern[0] )
        {
            if(correctPattern[1] == inputPattern[1])
            {
                if(correctPattern[2] == inputPattern[2])
                {
                    return true; 
                }
            }  
        }
        if(correctPattern[0] == inputPattern[2])
        {
            if(correctPattern[1] == inputPattern[1])
            {
                if(correctPattern[2] == inputPattern[0])
                {
                    return true; 
                }
            }
        }

        return false; 
    }
}
