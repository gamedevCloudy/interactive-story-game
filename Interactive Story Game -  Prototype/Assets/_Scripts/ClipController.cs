using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipController : MonoBehaviour
{
    [Header("reactionClip - Stella's Reactions")]
    [SerializeField]
    private GameObject lightKissClip;
    [SerializeField]
    private GameObject deepKissClip; 

    private float startTimer; 
    private int rand = 0; 

    void Update()
    {
        startTimer += Time.deltaTime; 

        if(startTimer > 30 && rand == 0 )
        {
            deepKissClip.SetActive(true); 
            lightKissClip.SetActive(false); 
            rand += 1; 
        }
    }
}
