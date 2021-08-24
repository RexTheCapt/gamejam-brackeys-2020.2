using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite sprite = null;

    void Start()
    {
        if (sprite == null)
            throw new System.Exception("Missing sprite");

        gameObject.GetComponent<Image>().sprite = sprite;
        
        //??????????????????????????//
    }
}
