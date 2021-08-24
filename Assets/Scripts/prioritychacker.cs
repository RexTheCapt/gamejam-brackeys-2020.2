using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prioritychacker : MonoBehaviour
{
    public Slider priority;
    public Text prioritylabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(priority.value == 0)
        {
            prioritylabel.text = ("Priority: " + "None");
        }
        else if (priority.value == 1)
        {
            prioritylabel.text = ("Priority: " + "Small");
        }
        else if (priority.value == 2)
        {
            prioritylabel.text = ("Priority: " + "Medium");
        }
        else if (priority.value == 3)
        {
            prioritylabel.text = ("Priority: " + "Big");
        }
        else if (priority.value == 4)
        {
            prioritylabel.text = ("Priority: " + "Very big");
        }
    }
}
