using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    [SerializeField]
    private SoundModel[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    public void Play(string name)
    {
        var sound = sounds.FirstOrDefault((model => model.name == name));
        if (sound == null)
        {
            Debug.Log($"This sound not found {name}");
            return;
        }

        sound.source.Play();
    }       
    }
