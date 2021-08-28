using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bootscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeout());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator timeout()
    {
        yield return new WaitForSecondsRealtime(5.9f);
        SceneManager.LoadScene("Level1");
    }
}
