using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAds : MonoBehaviour
{
    public Transform CornerTopLeft;
    public Transform CornerBottomRight;
    public float SpawnTimer = 10;
    public GameObject[] AdsToSpawn;

    private float _currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AdsToSpawn == null || AdsToSpawn.Length == 0)
            throw new Exception("No ads to spawn");

        _currentTimer += Time.deltaTime;

        if (_currentTimer > SpawnTimer)
        {
            System.Random rdm = new System.Random();
            BoxCollider2D spawnZone = gameObject.GetComponent<BoxCollider2D>();
            var randomAd = AdsToSpawn[rdm.Next(0, AdsToSpawn.Length)];
            
            // Get spawn width and height,
            var width = (spawnZone.bounds.size.x / 2) - randomAd.GetComponent<CloseAd>().Body.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            var height = spawnZone.bounds.size.z / 2;

            //System.Random rdm = new System.Random();

            //var randomAd = AdsToSpawn[rdm.Next(0, AdsToSpawn.Length)];
            //float width = randomAd.GetComponent<CloseAd>().Body.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            //Vector3 v = CornerTopLeft.position - CornerBottomRight.position;
            //Vector3 position = CornerBottomRight.position + Random.value * v;

            //Instantiate(original: randomAd, position: position, rotation: randomAd.transform.rotation);
            _currentTimer -= SpawnTimer;
        }
    }
}
