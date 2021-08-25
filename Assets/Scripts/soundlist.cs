using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundlist : MonoBehaviour
{
    public Sounds[] sounds;
    List<Component> komponenty = new List<Component>();

    public Slider SFXSlider;
    public Slider MUSICSlider;
    public Slider MASTER;

    public List<Component> components;
    public bool cacheNow;

    public Slider MASTER2;

    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sounds s in sounds)
        {
            if(s.name == "1" || s.name == "2" || s.name == "3")
            {
                s.source = gameObject.GetComponent<AudioSource>();
                //komponenty.Add(gameObject.GetComponent<AudioSource>());

                s.source.clip = s.sound;
                //s.source.volume = s.volume; <- change it to SFX slider vol. * master volume slider :D
                s.source.loop = s.loop;
            }
            else
            {
                s.source = gameObject.AddComponent<AudioSource>();
                //komponenty.Add(gameObject.GetComponent<AudioSource>());

                s.source.clip = s.sound;
                //s.source.volume = s.volume; <- change it to SFX slider vol. * master volume slider :D
                s.source.loop = s.loop;
            }
            
        }

        MASTER.value = PlayerPrefs.GetFloat("master", 1);
        MUSICSlider.value = PlayerPrefs.GetFloat("music", 0.9f);
        SFXSlider.value = PlayerPrefs.GetFloat("sfx", 0.9f);

        Cache();

        //StartCoroutine(playsoundonawake());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Sounds s in sounds)
        {
            

            if (s.name == "1" || s.name == "2" || s.name == "3")
            {
                s.source.volume = MUSICSlider.value * MASTER.value;
            }
            else
            {
                s.source.volume = SFXSlider.value * MASTER.value;
            }

        }

        music.volume = MUSICSlider.value * MASTER.value;

        SaveVolumeState();

        Events ev = GameObject.Find("PlayerEvents").GetComponent<Events>();

        


        if (ev.soundopened == false)
        {
            MASTER2.value = MASTER.value;
            MASTER.value = MASTER2.value;
        }
        else
        {
            MASTER.value = MASTER2.value;
        }
        
    }

    public void Refreshmusic(int musicnumber)
    {
        foreach (Sounds s in sounds)
        {
            if (s.name == musicnumber.ToString())
            {
                s.source = gameObject.GetComponent<AudioSource>();
                

                s.source.clip = s.sound;
                s.source.loop = s.loop;
            }

        }
    }

    void Cache()
    {
        components = new List<Component>();
        foreach (var component in GetComponents<Component>())
        {
            if (component != this) components.Add(component);
        }
    }

    public void SaveVolumeState()
    {
        PlayerPrefs.SetFloat("master", MASTER.value);
        PlayerPrefs.SetFloat("music", MUSICSlider.value);
        PlayerPrefs.SetFloat("sfx", SFXSlider.value);
    }

    public GameObject thisobject;

    public void StopSound()
    {
        //dontwork

    }

    private void Destroy(AudioSource[] audioSources)
    {
        throw new NotImplementedException();
    }

    public IEnumerator playsoundonawake()
    {
        yield return new WaitForSecondsRealtime(1);
        PlaySound("1");
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
