using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
   
     
{
    public float startTime=120f;
    public float currentTime=0f;
    [SerializeField]
    Text CountdownTimer;
    
    void Start()
    {
        currentTime = startTime;
    }

  
    void Update()
    {
        
        currentTime -= 1 * Time.deltaTime;
        CountdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            score.scoreValue = 0;
            SceneManager.LoadScene("level02");
        }
    }
}
