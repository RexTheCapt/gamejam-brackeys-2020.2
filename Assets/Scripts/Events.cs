using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Animator listanimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            listanimator.SetTrigger("on");
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            listanimator.SetTrigger("off");
        }

        if(Input.GetKey(KeyCode.LeftControl) == false)
        {
            listanimator.SetTrigger("off");
        }

    }
}
