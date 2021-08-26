using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class drag : MonoBehaviour, IDragHandler
{
    [Header("Required")]
    public Transform transformToMove;
    public Canvas canvas;
    [SerializeField] private DragType dragType = DragType.Normal;
    [Header("Popup stuff")]
    [SerializeField] private Transform parent;
    
    [Header("Other stuff")]
    [SerializeField] private RectTransform dragRectTransform;

    public Collider2D screenbounds;

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(dragType);

        //Debug.Log(Input.mousePosition.x + " " + Input.mousePosition.y);

        if(dragType == DragType.Normal)
        {
            if(Input.mousePosition.x < 1900 && Input.mousePosition.x > 10 && Input.mousePosition.y < 1082 && Input.mousePosition.y > 10)
            {
                Debug.Log("Normadrag");
                dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
        else
        {
            if(Input.mousePosition.x < 1900 && Input.mousePosition.x > 10 && Input.mousePosition.y < 1082 && Input.mousePosition.y > 10)
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out pos);
                transformToMove.position = canvas.transform.TransformPoint(pos);
            }
            
        }
    }

    private enum DragType
    {
        Normal,
        Ad
    }
}
