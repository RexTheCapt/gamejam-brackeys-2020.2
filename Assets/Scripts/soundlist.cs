using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundlist : MonoBehaviour
{
    public Sounds[] sounds;

    public Slider SFXSlider;
    public Slider MUSICSlider;
    public Slider MASTER;

    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            //s.source.volume = s.volume; <- change it to SFX slider vol. * master volume slider :D
            s.source.loop = s.loop;
        }

        MASTER.value = PlayerPrefs.GetFloat("master", 1);
        MUSICSlider.value = PlayerPrefs.GetFloat("music", 0.9f);
        SFXSlider.value = PlayerPrefs.GetFloat("sfx", 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = SFXSlider.value * MASTER.value;
        }

        music.volume = MUSICSlider.value * MASTER.value;

        SaveVolumeState();
    }

    public void SaveVolumeState()
    {
        PlayerPrefs.SetFloat("master", MASTER.value);
        PlayerPrefs.SetFloat("music", MUSICSlider.value);
        PlayerPrefs.SetFloat("sfx", SFXSlider.value);
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
