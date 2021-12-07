using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSoundClip : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio")] 
    [SerializeField] private List<AudioClip> attackClips;
    [SerializeField] private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EnemyFireBallSound()
    {
        _audioSource.clip = attackClips[0];
        _audioSource.Play();
    }

    public void EnemyHackSound()
    {
        _audioSource.clip = attackClips[1];
        _audioSource.Play();
    }
    
    public void EnemyGetHitSound()
    {
        _audioSource.clip = attackClips[2];
        _audioSource.Play();
    }
}
