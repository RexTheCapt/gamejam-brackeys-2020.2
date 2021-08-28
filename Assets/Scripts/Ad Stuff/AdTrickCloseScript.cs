using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdTrickCloseScript : MonoBehaviour
{
    public static int TotalPresses = 1;

    public void CloseAd()
    {
        CloseAd closeAd = transform.parent.GetComponent<CloseAd>();
        SpawnAds spawnAds;

        try
        {
            spawnAds = closeAd.spawner.GetComponent<SpawnAds>();
        }
        catch
        {
            Debug.LogError("transform.parent.GetComponent<CloseAd>().spawner was not set! Trying to find it automatically.");
            closeAd.spawner = GameObject.Find("Canvas");
            spawnAds = closeAd.spawner.GetComponent<SpawnAds>();
        };

        spawnAds._currentTimer += spawnAds.SpawnTimer * (TotalPresses++ * 5);
        closeAd.DestroyAd();
    }
}
