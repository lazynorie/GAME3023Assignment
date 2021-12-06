using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayTrack(MusicManager.TrackID.Overworld);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
