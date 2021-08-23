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
        if (AdsToSpawn == null || AdsToSpawn.Length == 0)
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
            BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            
            Vector2 location = new Vector2(transform.position.x, transform.position.y);
            Vector2 dimentions = new Vector2(boxCollider2D.bounds.size.x / 2, boxCollider2D.bounds.size.z / 2);

            Vector2 randomDimentions = new Vector2(Randomize(dimentions.x, dimentions.x * -1), Randomize(dimentions.y, dimentions.y * -1));

            Instantiate(AdsToSpawn[Random.Range(0, AdsToSpawn.Length - 1)], position: new Vector3(randomDimentions.x, 0, randomDimentions.y), rotation: transform.rotation);

            _currentTimer -= SpawnTimer;
        }
    }

    private float Randomize(float x, float y)
    {
        return Random.Range(x, y);
    }
}
