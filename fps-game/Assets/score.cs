using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class score : MonoBehaviour


{
    public  static int scoreValue=0;
    
    
  [SerializeField]
    Text killscore;

    void Start()
    {
        killscore= GetComponent<Text>();
    }


    void Update()
    {

        killscore.text = "Score: " + scoreValue +"/25";
        if (scoreValue == 25)
        {
            SceneManager.LoadScene("level02");
            scoreValue = 0;
        }
    }  
}
