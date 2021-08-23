using UnityEngine;

public class SpawnAds : MonoBehaviour
{
    public bool DisableTimer = false;
    public bool SpawnAd = false;

    public float SpawnTimer = 10;
    public float _currentTimer;
    public GameObject[] AdList;

    // Start is called before the first frame update
    void Start()
    {
        if (AdList == null || AdList.Length == 0)
            throw new System.Exception("No ads to spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (!DisableTimer)
            _currentTimer += Time.deltaTime;

        if (_currentTimer > SpawnTimer || SpawnAd)
        {
            var spawnBounds = gameObject.GetComponent<Canvas>().pixelRect;
            Vector2 dimentions = new Vector2(spawnBounds.size.x / 2, spawnBounds.size.y / 2);

            // X = Width
            // Y = Height
            Vector2 randomDimention = new Vector2(Randomize(dimentions.x, dimentions.x * -1), Randomize(dimentions.y, dimentions.y * -1));

            GameObject randomAd = AdList[Random.Range(0, AdList.Length)];
            GameObject go = Instantiate(randomAd, position: new Vector3(randomDimention.x, randomDimention.y, 0), rotation: transform.rotation);
            go.transform.parent = transform;
            go.GetComponent<drag>().SetCanvas(gameObject.GetComponent<Canvas>());

            if (_currentTimer > SpawnTimer)
                _currentTimer -= SpawnTimer;

            SpawnAd = false;
        }
    }

    private float Randomize(float x, float y)
    {
        return Random.Range(x, y);
    }
}
