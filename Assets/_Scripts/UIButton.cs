using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButton : MonoBehaviour
{


    public void StartGame()
    {
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("Save");
        //PlayerPrefs.DeleteKey("TimeToLoad");
        SceneManager.LoadScene("TestScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("TestScene");
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}