using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tabdragdetector : MonoBehaviour
{
    public int TabNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TabManager tb = GameObject.Find("chrome").GetComponent<TabManager>();
            tb.truedragging(TabNum);
        }
        else
        {
            TabManager tb = GameObject.Find("chrome").GetComponent<TabManager>();
            tb.falsedragging(TabNum);
        }

        //TabManager tb = GameObject.Find("chrome").GetComponent<TabManager>();
        //tb.falsedragging(TabNum);
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseExit()
    {
        
    }



    

}
