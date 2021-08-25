using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public Toggle autoplay;

    //public Clip

    //dont add any sounds
    public Sounds[] sounds;

    public Text pausetext;
    public bool ispaused = false;

    public int musiccount;

    public int musicname;
    public Text musicinfo;

    public GameObject musicplayer;

    public void ChangeAudioTime()
    {
        audioSource.time = audioSource.clip.length * slider.value;

        UpdateInfo();
    }

    public void PauseMusic()
    {
        /*
        if(ispaused == true)
        {
            foreach (Sounds s in sounds)
            {
                if (s.name == musicname.ToString())
                {
                    s.source.UnPause();
                }
            }

            pausetext.text = "PAUSE";
        }
        else if(ispaused == false)
        {
            foreach (Sounds s in sounds)
            {
                if (s.name == musicname.ToString())
                {
                    s.source.Pause();
                }
            }

            pausetext.text = "UNPAUSE";
        }

        UpdateInfo();

        */

    }

    public void showmusicplayer()
    {
        musicplayer.SetActive(true);
    }

    public void hidemusicplayer()
    {
        musicplayer.SetActive(false);
    }

    public void StopMusic()
    {
        foreach (Sounds s in sounds)
        {
            s.source.Stop();
        }
        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        snd.music.Stop();

        soundlist snd2 = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        snd2.PlaySound("stop");

        Destroy(GetComponent<AudioSource>());
        if (GetComponent<AudioSource>() == null)
        {
            Debug.Log("DELETED ALL AUDIOSOURCES");
        }
        else
        {
            Debug.LogError("OH NO");
        }
        gameObject.AddComponent<AudioSource>();
        soundlist sound = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        if(musicname == 1)
        {
            sound.Refreshmusic(2);
        }
        else if (musicname == 2)
        {
            sound.Refreshmusic(1);
        }

        //snd.StopSound();

        if (GetComponent<AudioSource>() != null)
        {
            //snd.StopSound();
        }

        //soundlist snd24 = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        //snd24.music.Stop();

        UpdateInfo();
    }

    public void PlayMusic()
    {
        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        //snd.music.Stop();

        if (GetComponent<AudioSource>() != null)
        {
            //snd.StopSound();
        }

        Destroy(GetComponent<AudioSource>());
        if (GetComponent<AudioSource>() == null)
        {
            Debug.Log("DELETED ALL AUDIOSOURCES");
        }
        else
        {
            Debug.LogError("OH NO");
        }
        gameObject.AddComponent<AudioSource>();
        soundlist sound = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        if (musicname == 1)
        {
            sound.Refreshmusic(2);
        }
        else if (musicname == 2)
        {
            sound.Refreshmusic(1);
        }

        //soundlist snd2 = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        //snd2.PlaySound("stop");

        snd.PlaySound(musicname.ToString());
    }

    public void NextMusic()
    {
        foreach (Sounds s in sounds)
        {
            s.source.Stop();
        }

        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        snd.music.Stop();

        if (GetComponent<AudioSource>() != null)
        {
            //snd.StopSound();
        }

        Destroy(GetComponent<AudioSource>());
        if (GetComponent<AudioSource>() == null)
        {
            Debug.Log("DELETED ALL AUDIOSOURCES");
        }
        else
        {
            Debug.LogError("OH NO");
        }
        gameObject.AddComponent<AudioSource>();
        soundlist sound = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        if (musicname == 1)
        {
            sound.Refreshmusic(2);
        }
        else if (musicname == 2)
        {
            sound.Refreshmusic(1);
        }

        //soundlist snd2 = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        //snd2.PlaySound("stop");

        if (musicname != (musiccount))
        {
            musicname += 1;
        }
        else
        {
            musicname = 1;
        }

        //audioSource.Stop();
        if(autoplay.isOn == true)
        {
            soundlist snd21 = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
            snd21.PlaySound(musicname.ToString());

            if(musicname == 1)
            {
                snd21.PlaySound("stop");
                snd21.PlaySound("1");
            }
        }

        UpdateInfo();
    }

    public void UpdateInfo()
    {
        musicinfo.text = ("NOW PLAYING: Music " + musicname + " of " + musiccount);
    }

    private void Start()
    {
        musicname = 1;
        PlayMusic();
        UpdateInfo();

        foreach (Sounds s in sounds)
        {
            s.source.Stop();
        }

        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        snd.PlaySound("3");
    }

    private void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source.Stop();
        }

        //soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        //snd.PlaySound("3");

        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        //snd.music.Stop();

        if (GetComponent<Rigidbody>() != null)
        {
            snd.StopSound();
        }

        snd.PlaySound(musicname.ToString());
    }


    // Update is called once per frame
    void Update()
    {
        
        soundlist snd = GameObject.Find("PlayerEvents").GetComponent<soundlist>();
        
        

        foreach (Sounds s in sounds)
        {
            if (s.name == musicname.ToString())
            {
                s.source.Play();
                slider.maxValue = s.dur;
                slider.value = s.source.time / s.dur;
            }
            else
            {
                //donothing :D
            }
        }
        
    }
}

