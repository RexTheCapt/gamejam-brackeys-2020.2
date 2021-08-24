using System.Collections.Generic;

using UnityEngine;

public class SpawnAds : MonoBehaviour
{
    public bool DisableTimer = false;
    public bool SpawnAd = false;
    public bool PurgeAds = false;

    public float SpawnTimer = 10;
    public float _currentTimer;
    public GameObject[] AdList;

    public List<GameObject> SpawnedAds = new List<GameObject>();
    private GameObject _midPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (AdList == null || AdList.Length == 0)
            throw new System.Exception("No ads to spawn");

        _midPoint = new GameObject();
        _midPoint.transform.parent = transform;
        Instantiate(_midPoint);
        _midPoint.transform.localPosition = Vector2.zero;
        _midPoint.name = $"Ads midpoint";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SpawnAd = true;

        if (PurgeAds)
        {
            for (int i = SpawnedAds.Count - 1; i >= 0; i--)
            {
                if (SpawnedAds[i] != null)
                    Destroy(SpawnedAds[i]);

                SpawnedAds.RemoveAt(i);
            }

            PurgeAds = false;
        }

        if ((_currentTimer > SpawnTimer && !DisableTimer) || SpawnAd)
        {
            Canvas canvas = gameObject.GetComponent<Canvas>();
            var spawnBounds = canvas.pixelRect;
            Vector2 dimentions = new Vector2(spawnBounds.size.x / 2, spawnBounds.size.y / 2);

            // X = Width
            // Y = Height
            Vector2 randomDimention = new Vector2(Randomize(dimentions.x, dimentions.x * -1), Randomize(dimentions.y, dimentions.y * -1));

            GameObject randomAd = AdList[Random.Range(0, AdList.Length)];
            GameObject go = Instantiate(randomAd);

            go.transform.SetParent(_midPoint.transform, false);
            go.transform.localPosition = new Vector3(randomDimention.x, randomDimention.y, 0);
            go.gameObject.GetComponentInChildren<drag>().canvas = canvas;
            go.gameObject.GetComponentInChildren<drag>().transformToMove = go.transform;
            
            SpawnedAds.Add(go);

            if (_currentTimer > SpawnTimer)
                _currentTimer -= SpawnTimer;

            SpawnAd = false;
        }
    }

    private void FixedUpdate()
    {
        if (!DisableTimer)
            _currentTimer += Time.deltaTime;
    }

    private float Randomize(float x, float y)
    {
        return Random.Range(x, y);
    }
}
