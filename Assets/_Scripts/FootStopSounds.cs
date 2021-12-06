using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootStopSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> footstepSoundClips;
    
    [SerializeField]
    private AudioSource soundSource;

    private PlayerBehaviour player;

    void Start()
    {
        player = GetComponentInParent<PlayerBehaviour>();
    }

    void PlayFootStep()
    {
        if (player.isInGrass)
        {
            soundSource.clip = footstepSoundClips[1];
        }
        else
        {
            soundSource.clip = footstepSoundClips[0];
        }
        soundSource.Play();
    }
    
    public enum ClipID
    {
        lightFootStep = 0,
        HeavyFootStep  
    }

    void PlayClip(ClipID id)
    {
        soundSource.clip = footstepSoundClips[(int)id];
        soundSource.Play();
    }
}
