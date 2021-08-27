using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAd : MonoBehaviour
{
    public GameObject Body;
    public GameObject spawner;

    public void DestroyAd()
    {
        if (spawner == null)
        {
            Debug.LogError("spawner is null! Trying to find it automatically.");
            spawner = GameObject.Find("Canvas");
        }

        spawner.GetComponent<SpawnAds>().PlayAdCloseSound();
        Destroy(gameObject);
    }

    public void SpawnMoreThenDestroyAd()
    {
        SpawnAds s;

        if (spawner != null)
        {
            s = spawner.GetComponent<SpawnAds>();
        }
        else
        {
            Debug.LogError("spawner is null! Trying to find it automatically.");
            spawner = GameObject.Find("Canvas");
            s = spawner.GetComponent<SpawnAds>();
        }

        s._currentTimer += s.SpawnTimer * Random.Range(2, 10);
        
        DestroyAd();
    }
}
