using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCommandHandler : MonoBehaviour
{
    public SpawnAds spawnAds;
    public CloseTerminal closeTerminal;
    public ConsoleOutputHandler ConsoleOutputHandler;
    public bool HandlerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HandlerActive)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TMPro.TMP_InputField tMP_InputField = GetComponent<TMPro.TMP_InputField>();
                string[] input = tMP_InputField.text.Split(' ');

                if (string.IsNullOrEmpty(input[0]))
                    return;

                if (input[0].Equals("help"))
                {
                    ConsoleOutputHandler.Append("Available commands:");
                    ConsoleOutputHandler.Append("help (Shows this useless help text)");
                    ConsoleOutputHandler.Append("close (Please dont use this command)");
                    ConsoleOutputHandler.Append("  Usage: close <terminal id> (Please deffinetely do NOT use this one)");
                    ConsoleOutputHandler.Append("list (You dont need this one, right?)");
                    ConsoleOutputHandler.Append("clear (Clears stuff...)");
                }
                else if (input[0].Equals("list"))
                {
                    List<GameObject> spawnedAds = spawnAds.SpawnedAds;

                    ConsoleOutputHandler.Append("Open terminals ID:");
                    foreach (var ad in spawnedAds)
                    {
                        if (ad == null)
                            continue;

                        ConsoleId consoleId = ad.GetComponent<ConsoleId>();

                        if (consoleId == null)
                            continue;

                        ConsoleOutputHandler.Append($"{consoleId.Id}");
                    }
                }
                else if (input[0].Equals("clear"))
                {
                    ConsoleOutputHandler.Clear();
                }
                else if (input[0].Equals("close"))
                {
                    if (input.Length == 2)
                    {
                        closeTerminal.Close(input[1]);
                    }
                    else
                    {
                        ConsoleOutputHandler.Append("Error: Close command requires console id.");
                        ConsoleOutputHandler.Append("Usage: close <id>");
                    }
                }
                else
                {
                    ConsoleOutputHandler.Append($"Unknown command \"{input[0]}\"");
                }

                tMP_InputField.text = "";
            }
        }
    }

    public void SetHandlerActive(bool toggle)
    {
        HandlerActive = toggle;
    }
}
