using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveAndQuit : MonoBehaviour
{
   
  PlayerPosSave playerPosData;

private void Start()
{
   playerPosData = FindObjectOfType<PlayerPosSave>();
}   public void quit()
   {
      playerPosData.playerPosSave();
      SceneManager.LoadScene("MainMenu");
   }
}