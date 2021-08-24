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

    public void SpawnMoreThenDestroyAd()
    {
        SpawnAds s = spawner.GetComponent<SpawnAds>();
        s._currentTimer += s.SpawnTimer * Random.Range(2, 10);
        
        DestroyAd();
    }
}
