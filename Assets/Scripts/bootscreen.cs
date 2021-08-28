using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bootscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator timeout()
    {
        yield return new WaitForSecondsRealtime(2.89f);
        SceneManager.LoadScene("Level1");
    }
}
