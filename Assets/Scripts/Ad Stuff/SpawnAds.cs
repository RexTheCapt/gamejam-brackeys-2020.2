using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SpawnAds : MonoBehaviour
{
    public bool EnableSpawnKey = false;
    public bool DisableTimer = false;
    public bool SpawnAd = false;
    public bool PurgeAds = false;

    public GameObject AdsParent;
    public float SpawnTimer = 10;
    public float _currentTimer;
    public int MaxAds = 50;
    public GameObject[] AdList;

    public List<GameObject> SpawnedAds = new List<GameObject>();

    //private GameObject _midPoint;
    private AudioClip _adCloseAudio;
    private AudioClip _adOpenAudio;

    // Start is called before the first frame update
    void Start()
    {
        _adCloseAudio = (AudioClip)Resources.Load("Sounds/BRECKEYS_Ad Close");
        if (_adCloseAudio == null)
            Debug.LogError("Ad close audio is null");

        _adOpenAudio = (AudioClip)Resources.Load("Sounds/BRECKEYS_Ad Open");
        if (_adOpenAudio == null)
            Debug.LogError("Ad open audio is null");

        if (AdList == null || AdList.Length == 0)
            throw new System.Exception("No ads to spawn");

        //_midPoint = new GameObject();
        //_midPoint.transform.parent = transform;
        //Instantiate(_midPoint);
        //_midPoint.transform.localPosition = Vector2.zero;
        //_midPoint.name = $"Ads midpoint";
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnedAds.Count > MaxAds)
        {
            for (int i = SpawnedAds.Count - 1; i >= 0; i--)
            {
                if (SpawnedAds[i] == null)
                    SpawnedAds.RemoveAt(i);
            }

            if (SpawnedAds.Count > MaxAds)
            {
                SceneManager.LoadScene("Loss");
            }
        }

        if (EnableSpawnKey && Input.GetKeyDown(KeyCode.S))
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

            go.transform.SetParent(AdsParent.transform, false);
            go.transform.localPosition = new Vector3(randomDimention.x, randomDimention.y, 0);
            go.gameObject.GetComponentInChildren<drag>().canvas = canvas;
            go.gameObject.GetComponentInChildren<drag>().transformToMove = go.transform;
            go.gameObject.GetComponentInChildren<CloseAd>().spawner = gameObject;
            
            SpawnedAds.Add(go);
            gameObject.GetComponent<AudioSource>().PlayOneShot(_adOpenAudio);

            if (_currentTimer > SpawnTimer)
                _currentTimer -= SpawnTimer;

            SpawnAd = false;
        }
    }

    public void PlayAdCloseSound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(_adCloseAudio);
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
