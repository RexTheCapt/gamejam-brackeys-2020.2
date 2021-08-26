using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TabManager : MonoBehaviour
{
    public Slider Tab1;
    public Slider Tab2;

    public bool draggingTab1 = false;
    public bool draggingTab2 = false;

    public bool ismoreOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Tab1.value < (Tab2.value - 0.2f) || Tab1.value < Tab2.value)
        {
            //nothing
        }
        else if (Tab1.value > (Tab2.value - 0.2f) || Tab1.value < Tab2.value || draggingTab1 == false)
        {
            if(Tab1.value != 0)
            {
                //Tab1.value -= (Tab2.value - Tab1.value);
            }
        }

        

        if(draggingTab1 == false)
        {
            Tab1.value = Mathf.Round(Tab1.value);
        }

        if (draggingTab2 == false)
        {
            Tab2.value = Mathf.Round(Tab2.value);
        }

        if(Tab1.value == Tab2.value)
        {
            if(Tab2.value != 0)
            {
                Tab2.value -= 0.0307f;
            }
            else
            {
                Tab2.value -= 0.0307f;
            }

        }

    }

    public void truedragging(int tab)
    {
        if(tab == 1)
        {
            draggingTab1 = true;
        }
        else if(tab == 2)
        {
            draggingTab2 = true;
        }

    }

    public GameObject morepanel;

    public void toggleMore()
    {
        if(ismoreOn == false)
        {
            morepanel.SetActive(true);
            ismoreOn = true;
        }
        else if (ismoreOn == true)
        {
            morepanel.SetActive(false);
            ismoreOn = false;
        }

    }


    public void falsedragging(int tab)
    {
        if (tab == 1)
        {
            draggingTab1 = false;
        }
        else if (tab == 2)
        {
            draggingTab2 = false;
        }
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

}
