using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerBehaviour player = FindObjectOfType<PlayerBehaviour>();
        player.OnEnterEncounterEvent.AddListener(EnterEncounterHandler);
        //player.OnExitBattleEvent.AddListener(ExitCoutnerHandler);
        
        //Instance.PlayTrack(TrackID.Overworld);
    }

    private void ExitCoutnerHandler()
    {
        PlayTrack(TrackID.Overworld);
    }


    private void EnterEncounterHandler()
    {
        PlayTrack(TrackID.Battle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
