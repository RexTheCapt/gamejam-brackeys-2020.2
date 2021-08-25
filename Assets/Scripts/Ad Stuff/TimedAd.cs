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
            gameObject.GetComponent<CloseAd>().spawner.GetComponent<SpawnAds>()._currentTimer += Time.deltaTime;
        }
        //else
        //{
        //    TextToUpdate.text = $"Time left til time boost: {TimeLeft:0.0}s";
        //}
    }
}
