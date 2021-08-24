using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAd : MonoBehaviour
{
    public GameObject Body;
    public GameObject spawner;

    public void DestroyAd()
    {
        spawner.GetComponent<SpawnAds>().PlayAdCloseSound();
        Destroy(gameObject);
    }
}
