using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenLoader : MonoBehaviour
{
    public GameObject wincanvas;
    public AudioSource endmusic;

    public Text exitbuttontext;

    // Start is called before the first frame update
    void Start()
    {
        
        
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
        exitbuttontext.text = "BYE :D";
        yield return new WaitForSecondsRealtime(1f);
        Application.Quit();
    }
}
