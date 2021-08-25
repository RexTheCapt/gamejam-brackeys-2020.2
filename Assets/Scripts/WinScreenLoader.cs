using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenLoader : MonoBehaviour
{
    public GameObject wincanvas;
    public AudioSource endmusic;

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
        yield return new WaitForSecondsRealtime(2.4f);
        wincanvas.SetActive(true);
        endmusic.Play();
    }
}
