using UnityEngine;

public class ConsoleCloseDelay : MonoBehaviour
{
    [Header("Manually set")]
    public GameObject CurrentConsoleOutput;

    [Header("Automatically set")]
    public float TimeToClose;
    public bool Closing = false;
    public ConsoleOutputHandler OutputHandler;

    // Start is called before the first frame update
    void Start()
    {
        TimeToClose = Random.value * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Closing)
        {
            TimeToClose -= Time.deltaTime;

            RandomConsoleOutput randomConsoleOutput = CurrentConsoleOutput.GetComponent<RandomConsoleOutput>();
            if (randomConsoleOutput)
            {
                Destroy(randomConsoleOutput);
                CurrentConsoleOutput.GetComponent<TMPro.TMP_Text>().color = Color.red;
            }

            if (TimeToClose < 0)
            {
                OutputHandler.Append($"[{GetComponent<ConsoleId>().Id}] Closed");
                Destroy(gameObject);
            }
        }
    }

    internal void Close(ConsoleOutputHandler consoleOutput)
    {
        OutputHandler = consoleOutput;
        Closing = true;
    }
}
