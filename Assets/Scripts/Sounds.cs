using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip sound;

    public float volume;
    public float pitch;
    public bool loop;
    public float dur;

    public AudioSource source;
}
