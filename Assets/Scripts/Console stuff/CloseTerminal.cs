using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTerminal : MonoBehaviour
{
    public ConsoleOutputHandler consoleOutput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close(string consoleId)
    {
        List<GameObject> spawnedAds = GetComponent<SpawnAds>().SpawnedAds;

        bool closedTerminal = false;
        for (int i = spawnedAds.Count - 1; i >= 0; i--)
        {
            if (spawnedAds[i] == null)
            {
                spawnedAds.RemoveAt(i);
                continue;
            }

            if (spawnedAds[i].GetComponent<ConsoleId>().Id.Equals(consoleId))
            {
                spawnedAds[i].GetComponent<ConsoleCloseDelay>().Close(consoleOutput);
                spawnedAds.RemoveAt(i);
                closedTerminal = true;
                break;
            }
        }

        if (closedTerminal)
        {
            consoleOutput.Append($"Closing terminal \"{consoleId}\" ...");
        }
        else
        {
            consoleOutput.Append($"Unknown terminal \"{consoleId}\"");
        }
    }
}
