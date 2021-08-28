using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class WinScreenLoader : MonoBehaviour
{
    public GameObject wincanvas;
    public AudioSource endmusic;

    public Text exitbuttontext;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();
    [DllImport("user32.dll", SetLastError = true)]
    static extern int MessageBox(int hwnd, string lpText, string lpCaption, uint uType);

    public static System.IntPtr GetWindowHandle()
    {
        return GetActiveWindow();
    }

    // Start is called before the first frame update
    void Start()
    {
        //messagebox test
        MessageBox(1, "Thanks for playing!", "The end", 0);
    }



    private void Awake()
    {
        wincanvas.SetActive(false);
        StartCoroutine(justwait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator justwait()
    {
        yield return new WaitForSecondsRealtime(1.1f);
        wincanvas.SetActive(true);
        endmusic.Play();
    }

    public void exitinvoker()
    {
        StartCoroutine(Exitgame());
    }

    public IEnumerator Exitgame()
    {
        Debug.Log("exit game");
        exitbuttontext.text = "BYE :D";
        yield return new WaitForSecondsRealtime(1f);
        Application.Quit();
    }
}
