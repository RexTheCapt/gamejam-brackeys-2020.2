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
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            listanimator.SetTrigger("on");
            //cantriggerliston = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            listanimator.SetTrigger("off");
        }

        

    }

    public IEnumerator cooldown()
    {
        return new WaitForSecondsRealtime(0.99f);
        cantriggerliston = true;
    }

    public IEnumerator refresh()
    {
        return new WaitForSecondsRealtime(1);
        cantriggerliston = true;
        //StartCoroutine(refresh());
    }
}
