using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deleteemail : MonoBehaviour
{
    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void checkfordeleteemail()
    {
        if(message.text == "Press OK to delete your email.")
        {
            Events ev = GameObject.Find("PlayerEvents").GetComponent<Events>();
            ev.deletemessagecontent();
        }
    }

}
