using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCommandHandler : MonoBehaviour
{
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

                if (input[0].Equals("close"))
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
