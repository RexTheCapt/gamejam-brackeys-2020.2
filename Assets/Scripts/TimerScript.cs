using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeftInSeconds = 120;
    public GameObject[] TimerGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeftInSeconds -= Time.deltaTime;

        foreach (GameObject TimerGameObject in TimerGameObjects)
        {
            Text text = TimerGameObject.GetComponent<Text>();
            text.text = $"{GetMinutes():0}:{GetSeconds():00} Left";

            if (TimeLeftInSeconds <= 30)
            {
                if ((int)TimeLeftInSeconds % 2 == 0)
                {
                    text.color = new Color(1, 1, 1);
                }
                else
                {
                    text.color = new Color(1, 0, 0);
                }
            }
        }

        if (TimeLeftInSeconds <= 0)
            SceneManager.LoadScene("Loss");
    }

    private int GetSeconds()
    {
        return (int)(TimeLeftInSeconds % 60);
    }

    private int GetMinutes()
    {
        return (int)TimeLeftInSeconds / 60;
    }
}
