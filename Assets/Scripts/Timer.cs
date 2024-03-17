using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

//https://www.youtube.com/watch?v=HmHPJL-OcQE&t=638s&ab_channel=GameDevBeginner

public class Timer : MonoBehaviour
{
    [Tooltip("seconds")]
    [SerializeField]
    float timeValue = 60;

    [Tooltip("dispay text")]
    [SerializeField]
    Text timeText;

    [SerializeField] GameObject timeOutMenu;


    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0) 
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            Debug.Log("time out");
            timeOutMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
            Cursor.visible = true; // Makes the cursor visible
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
