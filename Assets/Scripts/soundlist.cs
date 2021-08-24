using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundlist : MonoBehaviour
{
    public Sounds[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string name)
    {
        foreach(Sounds s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }

}
