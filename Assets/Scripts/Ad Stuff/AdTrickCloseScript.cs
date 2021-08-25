using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdTrickCloseScript : MonoBehaviour
{
    public static int TotalPresses = 0;

    public void CloseAd()
    {
        CloseAd closeAd = transform.parent.GetComponent<CloseAd>();
        SpawnAds spawnAds = closeAd.spawner.GetComponent<SpawnAds>();

        spawnAds._currentTimer += spawnAds.SpawnTimer * (TotalPresses++);
        closeAd.DestroyAd();
    }
}
