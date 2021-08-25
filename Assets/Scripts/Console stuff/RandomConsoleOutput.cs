using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class RandomConsoleOutput : MonoBehaviour
{
    public int lineNr = 0;
    public int linesBack = 30;

    void Update()
    {
        var tmp = GetComponent<TMP_Text>();

        if (tmp != null)

        tmp.text = $"{MobyDick.GetLine(lineNr++, linesBack)}";
    }
}
