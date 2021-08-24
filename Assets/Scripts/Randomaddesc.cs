using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomaddesc : MonoBehaviour
{
    public Text errorlabel;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 4);

        switch(random)
        {
            case 0:
                errorlabel.text = "System.FormatException";
                break;
            case 1:
                errorlabel.text = "Unable to delete files";
                break;
            case 2:
                //donothing leave default message
                break;
            case 3:
                errorlabel.text = ":)";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
