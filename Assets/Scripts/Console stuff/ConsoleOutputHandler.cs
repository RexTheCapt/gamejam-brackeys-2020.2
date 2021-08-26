using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleOutputHandler : MonoBehaviour
{
    public int MaxLines = 20;
    public List<string> lines = new List<string>();

    public void Append(string text)
    {
        lines.Add(text);

        while (lines.Count > MaxLines)
            lines.RemoveAt(0);

        TMPro.TMP_Text tMP_Text = GetComponent<TMPro.TMP_Text>();
        tMP_Text.text = "";

        foreach (string line in lines)
        {
            tMP_Text.text += $"{line}\n";
        }
    }
}
