using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=HmHPJL-OcQE&t=638s&ab_channel=GameDevBeginner

public class Timer : MonoBehaviour
{
    [Tooltip("seconds")]
    [SerializeField]
    float timeValue = 60;

    [Tooltip("dispay text")]
    [SerializeField]
    Text timeText;

    [Tooltip("lose scene if player ran out of time")]
    [SerializeField]
    string loseScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0) 
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(loseScene);
        }
        DisablayTime(timeValue);
    }

    private void DisablayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes =Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
