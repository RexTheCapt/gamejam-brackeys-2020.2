using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public List<CreditSection> Credits;

    public AnimationCurve AlphaCurve;

    private List<CreditSection> RunningCredits;

    void Start()
    {
        StartRunningCredits();
    }
    
    void Update()
    {
        if (RunningCredits.Count == 0)
            StartRunningCredits();
        else
            RunCredits();
    }

    private void StartRunningCredits()
    {
        RunningCredits = Credits.OrderBy(_ => Guid.NewGuid()).ToList();
        StartNextCredit();
    }

    private void RunCredits()
    {
        if (RunningCredits.First().FinishedRunning())
        {
            RunningCredits.RemoveAt(0);
            StartNextCredit();
        }
    }

    private void StartNextCredit()
    {
        if (RunningCredits.Count > 0)
            RunningCredits.First().StartShowing(AlphaCurve);
    }

    public static void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }
}
