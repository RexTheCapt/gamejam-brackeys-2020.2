using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedAd : MonoBehaviour
{
    public float TimeLeft;
    public Text TextToUpdate;

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = Random.Range(5, 20);
    }

    // Update is called once per frame
    void Update()
    {
        //TimeLeft -= Time.deltaTime;

        //if (TimeLeft < 0)
        {
            CloseAd closeAd = gameObject.GetComponent<CloseAd>();
            SpawnAds spawnAds;
            try
            {
                spawnAds = closeAd.spawner.GetComponent<SpawnAds>();
            }
            catch
            {
                // Why does this keep being blank? It is getting set in SpawnAds.cs!
                // It works on the first time accelerator!
                // Why cant it just work for them all?
                Debug.LogError("gameObject.GetComponent<SpawnAds>().Spawner was not set! Trying to self assign");
                closeAd.spawner = GameObject.Find("Canvas");
                return;
            }
            spawnAds._currentTimer += Time.deltaTime;
        }
        //else
        //{
        //    TextToUpdate.text = $"Time left til time boost: {TimeLeft:0.0}s";
        //}
    }
}
