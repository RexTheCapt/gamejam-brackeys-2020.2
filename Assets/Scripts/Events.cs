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
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightControl))
        {
            listanimator.SetBool("Show", true);
        }
        else
        {
            listanimator.SetBool("Show", false);
        }
    }
}
