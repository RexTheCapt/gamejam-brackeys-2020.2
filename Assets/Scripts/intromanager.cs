using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intromanager : MonoBehaviour
{
    public GameObject p4gpanel;
    public Animator p4g;
    public GameObject animationcanvas;

    public GameObject secondcanvas;
    public GameObject skipbutton;

    public GameObject plotPanel;
    public GameObject missionpanel;

    public Animator missionanimator;
    public AudioSource melody;
    public float waitformusicinsec;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cooldown());
        p4gpanel.SetActive(true);

        StartCoroutine(musiccooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator musiccooldown()
    {
        yield return new WaitForSecondsRealtime(waitformusicinsec);
        melody.Play();
    }

    public IEnumerator cooldown()
    {
        yield return new WaitForSecondsRealtime(8f);
        animationcanvas.SetActive(false);
        secondcanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        skipbutton.SetActive(true);
    }

    public void nextclick()
    {
        plotPanel.SetActive(false);
        missionpanel.SetActive(true);
        StartCoroutine(NextClick());
    }

    IEnumerator NextClick()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        missionanimator.SetTrigger("out");
        yield return new WaitForSecondsRealtime(3.7f);
        SceneManager.LoadScene("boot");
    }
}
