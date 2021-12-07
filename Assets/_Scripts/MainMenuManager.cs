using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayTrack(MusicManager.TrackID.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
