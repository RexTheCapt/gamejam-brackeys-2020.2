using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAd : MonoBehaviour
{
    public GameObject Body;

    public void DestroyAd()
    {
        Destroy(gameObject);
    }
}
