using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Hide cconstructor, add a static instance, and a public getter and no setter
//Yeah Singleton! 
public class MusicManager : MonoBehaviour
{
    private MusicManager() { }
    private static MusicManager instance = null;

    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MusicManager>();
                DontDestroyOnLoad(instance.transform.root);
            }

            return instance;
        }
        private set { instance = value; }
    }

    [SerializeField]
    List<AudioClip> musicTracks;
    [SerializeField] 
    AudioSource musicSource;

    [SerializeField] private AudioMixer mixer;
    public enum TrackID
    {
        Overworld = 0,
        Battle  
    }

    public void PlayTrack(TrackID id)
    {
        musicSource.clip = musicTracks[(int)id];
        musicSource.Play();
    }

    public void DestroyAllClones()
    {
        MusicManager[] clones = FindObjectsOfType<MusicManager>();
        foreach (MusicManager clone in clones)
        {
            //kill it if it's not the original
            if (clone != Instance)
            {
                Destroy(clone.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerBehaviour player = FindObjectOfType<PlayerBehaviour>();
        player.OnEnterEncounterEvent.AddListener(EnterEncounterHandler);
        DestroyAllClones();
        //player.OnExitBattleEvent.AddListener(ExitCoutnerHandler);
        
        //Instance.PlayTrack(TrackID.Overworld);
    }

    public void ExitCoutnerHandler()
    {
        PlayTrack(TrackID.Overworld);
    }


    public void EnterEncounterHandler()
    {
        PlayTrack(TrackID.Battle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float volumeDB)
    {
        mixer.SetFloat("VolumeMusic", volumeDB);
    }
}
