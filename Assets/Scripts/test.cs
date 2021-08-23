using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool mousedown;

    public RectTransform windowcords;
    public float targetposx;
    public float targetposy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mousedown == true)
        {
            targetposx = Input.mousePosition.x - windowcords.position.x;
            targetposy = Input.mousePosition.y - windowcords.position.y;

            windowcords.transform.position = new Vector2(targetposx, targetposy);
        }
    }

    private void OnMouseDown()
    {
        mousedown = true;
    }

    private void OnMouseUp()
    {
        mousedown = false;
    }

    
}
