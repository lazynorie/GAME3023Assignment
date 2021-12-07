using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosSave : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Saved")==1/*&& PlayerPrefs.GetInt("TimeToLoad") == 1*/)
        {
            float positionX = player.transform.position.x;
            float positionY = player.transform.position.y;
            positionX = PlayerPrefs.GetFloat("PlayerPositionX");
            positionY = PlayerPrefs.GetFloat("PlayerPositionY");
            player.transform.position = new Vector2(positionX, positionY);
            //PlayerPrefs.SetInt("TimeToLoad",0);
            PlayerPrefs.Save();
        }
    }

    public void playerPosSave()
    {
        PlayerPrefs.SetFloat("PlayerPositionX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY",player.transform.position.y);
        PlayerPrefs.SetInt("Saved",1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {
       // PlayerPrefs.SetInt("TimeToLoad",1);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
