using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewBehaviourScript controller = GameObject.Find("Player").GetComponent<NewBehaviourScript>();
        controller.isgrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NewBehaviourScript controller = GameObject.Find("Player").GetComponent<NewBehaviourScript>();
        controller.isgrounded = false;
    }
}
