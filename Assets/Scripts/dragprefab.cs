using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragprefab : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform dragRectTransform2;
    [SerializeField] private Canvas canvas2 = null;

    public void OnDrag(PointerEventData eventData)
    {
        //esds
        dragRectTransform2.anchoredPosition += eventData.delta / canvas2.scaleFactor;
    }

    public void SetCanvas(Canvas canvas)
    {
        this.canvas2 = canvas;
    }
}
