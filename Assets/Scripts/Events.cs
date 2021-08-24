using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public Animator listanimator;
    public bool cantriggerliston = true;

    public Animator start;
    public bool startopened = false;

    public Animator sound;
    public bool soundopened = false;

    public Slider volumeslider;
    public Text volumetext;

    public GameObject startmenu;
    public GameObject soundmenu;

    public InputField messagefield;
    public GameObject optionswindow;
    // Start is called before the first frame update
    void Start()
    {
        ///StartCoroutine(refresh());
        ///
        startmenu.SetActive(true);
        soundmenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        volumetext.text = volumeslider.value.ToString();

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightControl))
        {
            if (!listanimator.GetBool("Show"))
            {
                soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
                snd.PlaySound("paper");
            }

            listanimator.SetBool("Show", true);
            messagefield.readOnly = true;
        }
        else
        {
            if (listanimator.GetBool("Show"))
            {
                soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
                snd.PlaySound("paperclose");
            }

            listanimator.SetBool("Show", false);
            messagefield.readOnly = false;
        }

        /*
        if(Input.GetKey(KeyCode.LeftControl) == false && Input.GetKeyUp(KeyCode.RightControl) || Input.GetKey(KeyCode.RightControl) == false && Input.GetKeyUp(KeyCode.LeftControl))
        {
            soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
            snd.PlaySound("paperclose");
        }
        */

        //if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        //{
        //}

        //if (Input.GetKey(KeyCode.LeftControl) == true && Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey(KeyCode.RightControl) == true && Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //}


    }

    public void optionsshow()
    {
        optionswindow.SetActive(true);
    }

    public void optionshide()
    {
        optionswindow.SetActive(false);
    }


    public void textchanged()
    {
        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        snd.PlaySound("key" + Random.Range(0, 12).ToString());
        ///.PlaySound("key1");


    }

    public void SendFinalMessage()
    {
        string messagetypedin = messagefield.text.ToString();

        if(StringCompare(messagetypedin, "Dear Customer’s Hell Inc, I wish to complain about your product that I purchased on 29 / 08 / 2021. I am complaining because it is malfunctioning. To resolve this problem I would like you to pay me back the amount of 10 dollars. I look forward to hearing from you as soon as possible. Sincerely, Your Customer") < 90)
        {
            Debug.LogWarning("u failed LOLW" + "ur score is: " + StringCompare(messagetypedin, "Dear Customer’s Hell Inc, I wish to complain about your product that I purchased on 29 / 08 / 2021. I am complaining because it is malfunctioning. To resolve this problem I would like you to pay me back the amount of 10 dollars. I look forward to hearing from you as soon as possible. Sincerely, Your Customer"));
        }
        else
        {
            Debug.Log("u won!");
            //LOLW
        }


    }

    public void togglestart()
    {
        if(startopened == true)
        {
            startopened = false;
            start.SetTrigger("close");
        }
        else
        {
            startopened = true;
            start.SetTrigger("open");
        }


    }

    public void togglesound()
    {
        if (soundopened == true)
        {
            soundopened = false;
            sound.SetTrigger("close1");
        }
        else
        {
            soundopened = true;
            sound.SetTrigger("open1");
        }
    }


    static double StringCompare(string a, string b)
    {
        if (a == b) //Same string, no iteration needed.
            return 100;
        if ((a.Length == 0) || (b.Length == 0)) //One is empty, second is not
        {
            return 0;
        }
        double maxLen = a.Length > b.Length ? a.Length : b.Length;
        int minLen = a.Length < b.Length ? a.Length : b.Length;
        int sameCharAtIndex = 0;
        for (int i = 0; i < minLen; i++) //Compare char by char
        {
            if (a[i] == b[i])
            {
                sameCharAtIndex++;
            }
        }
        return sameCharAtIndex / maxLen * 100;
    }



}
