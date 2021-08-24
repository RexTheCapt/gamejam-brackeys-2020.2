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
        string[] text = new string[] {
            "System.FormatException",
            "Unable to delete files",
            "",
            ":)",
            "VIRUS DETECTED",
            "What is the meaning of life?",
            "Press OK to delete your email."
        };
        errorlabel.text = text[Random.Range(0, text.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
