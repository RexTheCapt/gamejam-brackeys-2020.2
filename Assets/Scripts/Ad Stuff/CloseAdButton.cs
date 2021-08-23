using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAdButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<CloseAd>().DestroyAd();
    }
}
