using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public RectTransform tab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector2 localPosition = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(tab, Input.mousePosition, null, out localPosition);
        tab.position = tab.TransformPoint(localPosition);
    }

}
