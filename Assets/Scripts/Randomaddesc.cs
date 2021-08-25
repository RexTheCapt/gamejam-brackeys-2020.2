using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomaddesc : MonoBehaviour
{
    public Text errorlabel;
    [TextArea]
    public string[] text = new string[] {
            "System.FormatException",
            "Unable to delete files",
            "",
            ":)",
            "VIRUS DETECTED",
            "What is the meaning of life?",
            "Press OK to OK",
            "OK",
            "Task failed succesfully",
            "Boneless Chicken",
            "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
            @"Error Occured at (line 1249; char 11)
Error: Type mismatch
Code: 820A400
Source: Msoft VBscript runtime error"
        };

    // Start is called before the first frame update
    void Start()
    {

        //random dialogbox messages :D

        
        errorlabel.text = text[Random.Range(0, text.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
