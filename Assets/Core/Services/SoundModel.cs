using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SoundModel
{
    public string name;
    public AudioClip clip;
    [Range(0,1)]
    public float pitch;
    [Range(0,1)]
    public float volume;

    public bool loop;
    
    [HideInInspector] 
    public AudioSource source;

}