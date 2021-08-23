using UnityEngine;

public class SpawnAds : MonoBehaviour
{
    public Transform CornerTopLeft;
    public Transform CornerBottomRight;
    public float SpawnTimer = 10;
    public GameObject[] AdList;

    private float _currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (AdList == null || AdList.Length == 0)
            throw new System.Exception("No ads to spawn");

        Vector2 offset = gameObject.GetComponent<BoxCollider2D>().offset;
        if (offset.x != 0 || offset.y != 0)
            Debug.LogWarning("BoxCollider2D offset for ad spawning is not 0,0!");
    }

    // Update is called once per frame
    void Update()
    {
        _currentTimer += Time.deltaTime;

        if (_currentTimer > SpawnTimer)
        {
            Bounds spawnBounds = gameObject.GetComponent<BoxCollider2D>().bounds;
            Vector2 dimentions = new Vector2(spawnBounds.size.x / 2, spawnBounds.size.y / 2);

            // X = Width
            // Y = Height
            Vector2 randomDimention = new Vector2(Randomize(dimentions.x, dimentions.x * -1), Randomize(dimentions.y, dimentions.y * -1));

            GameObject randomAd = AdList[Random.Range(0, AdList.Length)];
            Instantiate(randomAd, position: new Vector3(randomDimention.x, randomDimention.y, 0), rotation: transform.rotation);

            _currentTimer -= SpawnTimer;
        }
    }

    private float Randomize(float x, float y)
    {
        return Random.Range(x, y);
    }
}
