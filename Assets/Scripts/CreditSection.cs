using System;
using UnityEngine;
using UnityEngine.UI;

public class CreditSection : MonoBehaviour
{
    private Text[] SubTexts;
    
    private float StartTime;
    
    private float FinishTime;

    private AnimationCurve AlphaCurve;
    
    void Start()
    {
        SubTexts = transform.GetComponentsInChildren<Text>();
        SetAlpha(0f);
    }

    void Update() 
    {
        if (FinishedRunning())
        {
            SetAlpha(0f);
            gameObject.SetActive(false);
        } else 
            SetAlpha(GetAlpha());
    }

    public void StartShowing(AnimationCurve alphaCurve)
    {
        if (alphaCurve.length < 2)
            throw new ArgumentException("animation curve must have at least two keys");
        
        AlphaCurve = alphaCurve;
        StartTime = Time.time;
        FinishTime = Time.time + alphaCurve[alphaCurve.length - 1].time;

        gameObject.SetActive(true);
    }

    public bool FinishedRunning()
    {
        return Time.time >= FinishTime;
    }

    private float GetAlpha()
    {
        return AlphaCurve.Evaluate(Time.time - StartTime);
    }

    private void SetAlpha(float alpha)
    {
        foreach (var subText in SubTexts)
        {
            var color = subText.color;
            color.a = alpha;
            subText.color = color;
        }
    }
}