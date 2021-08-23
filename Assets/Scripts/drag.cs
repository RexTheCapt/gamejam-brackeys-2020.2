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
    public Canvas canvas = null;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(dragType);

        if (dragType == DragType.Normal)
        {
            Debug.Log("Normadrag");
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        else
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out pos);
            transformToMove.position = canvas.transform.TransformPoint(pos);
        }
    }
    
    public Transform transformToMove;

    private enum DragType
    {
        Normal,
        Ad
    }
}
