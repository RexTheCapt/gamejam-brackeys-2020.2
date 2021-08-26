using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SpawnAds : MonoBehaviour
{
    public bool EnableSpawnKey = false;
    public bool DisableLoseCondition = false;
    public bool DisableTimer = false;
    public bool SpawnAd = false;
    public bool PurgeAds = false;

    public GameObject ComputerHealth;
    public GameObject AdsParent;
    public Vector2 SpawnOffset;
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
        for (int i = SpawnedAds.Count - 1; i >= 0; i--)
        {
            if (SpawnedAds[i] == null)
                SpawnedAds.RemoveAt(i);
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

        System.DateTime start = System.DateTime.Now;
        while ((_currentTimer > SpawnTimer && !DisableTimer) || SpawnAd)
        {
            Canvas canvas = gameObject.GetComponent<Canvas>();
            var spawnBounds = new Bounds(canvas.pixelRect.center, new Vector3(canvas.pixelRect.size.x - (SpawnOffset.x * 2), canvas.pixelRect.size.y - (SpawnOffset.y * 2), 0));
            Vector2 dimentions = new Vector2(spawnBounds.size.x / 2, spawnBounds.size.y / 2);

            // X = Width
            // Y = Height
            Vector2 randomDimention = new Vector2(Randomize(dimentions.x, dimentions.x * -1), Randomize(dimentions.y, dimentions.y * -1));

            GameObject randomAd = AdList[Random.Range(0, AdList.Length)];
            GameObject go = Instantiate(randomAd);

            go.transform.SetParent(AdsParent.transform, false);
            go.transform.localPosition = new Vector3(randomDimention.x, randomDimention.y, 0);
            var drag = go.gameObject.GetComponentInChildren<drag>();
            if (drag != null)
            {
                drag.canvas = canvas;
                go.gameObject.GetComponentInChildren<drag>().transformToMove = go.transform;
            }
            var closeAd = gameObject.GetComponentInChildren<CloseAd>();
            if (closeAd != null)
                closeAd.spawner = gameObject;
            
            SpawnedAds.Add(go);
            gameObject.GetComponent<AudioSource>().PlayOneShot(_adOpenAudio);

            if (_currentTimer > SpawnTimer)
                _currentTimer -= SpawnTimer;

            SpawnAd = false;

            if (start.AddMilliseconds(100) < System.DateTime.Now)
            {
               Debug.LogWarning("Too many popups to spawn!");
               PurgeAds = true;
               _currentTimer = 0;
               break;
            }
        }
        //Debug.Log($"Used {(System.DateTime.Now) - start} seconds to spawn ads");

        #region PC Health stuff
        if (ComputerHealth != null)
        {
            Text healthText = ComputerHealth.GetComponent<Text>();
            float adPercent = (float)SpawnedAds.Count / MaxAds;

            if (adPercent < .2f)
            {
                healthText.text = "PC Life: OK";
                healthText.color = new Color(0, 0, 1);
            }
            else if (adPercent < .4f)
            {
                healthText.text = "PC Life: Mostly OK";
                healthText.color = new Color(0, 1, 0);
            }
            else if (adPercent < .6f)
            {
                healthText.text = "PC Life: Not OK";
                healthText.color = new Color(1, 1, 0);
            }
            else if (adPercent < .8f)
            {
                healthText.text = "PC Life: HELP ME!!!";
                healthText.color = new Color(1, 0, 0);
            }
        }
        #endregion

        if (!DisableLoseCondition)
        {
            if (SpawnedAds.Count > MaxAds)
                SceneManager.LoadScene("loss");
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
