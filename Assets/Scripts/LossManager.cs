using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
    public float DelayBeforeCredits;

    private float FinishTime;
    
    void Start()
    {
        FinishTime = Time.time + DelayBeforeCredits;
    }

    void Update()
    {
        if (Time.time > FinishTime)
            SceneManager.LoadScene("Credits");
    }
}
