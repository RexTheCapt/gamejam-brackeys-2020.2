using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Animator listanimator;
    public bool cantriggerliston = true;
    // Start is called before the first frame update
    void Start()
    {
        ///StartCoroutine(refresh());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightControl))
        {
            listanimator.SetBool("Show", true);
        }
        else
        {
            listanimator.SetBool("Show", false);
        }

        /*
        if(Input.GetKey(KeyCode.LeftControl) == false && Input.GetKeyUp(KeyCode.RightControl) || Input.GetKey(KeyCode.RightControl) == false && Input.GetKeyUp(KeyCode.LeftControl))
        {
            soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
            snd.PlaySound("paperclose");
        }
        */

        if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
            snd.PlaySound("paperclose");
        }

        if (Input.GetKey(KeyCode.LeftControl) == true && Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey(KeyCode.RightControl) == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
            snd.PlaySound("paper");
        }


    }


    public void textchanged()
    {
        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        snd.PlaySound("key" + Random.Range(0, 12).ToString());
        ///.PlaySound("key1");


    }



}
