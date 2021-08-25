using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class drag : MonoBehaviour, IDragHandler
{
    [Header("Ad stuff")]
    [SerializeField] private Transform parent;
    [SerializeField] private DragType dragType = DragType.Normal;
    
    [Header("Other stuff")]
    [SerializeField] private RectTransform dragRectTransform;
    public Canvas canvas;

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
    
    public Transform transformToMove;

    private enum DragType
    {
        Normal,
        Ad
    }
}
