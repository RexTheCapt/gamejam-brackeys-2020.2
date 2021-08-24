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
    }
}
