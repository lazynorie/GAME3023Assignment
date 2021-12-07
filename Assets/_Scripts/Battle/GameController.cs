using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private PlayerPosSave playerPosData;
    private List<FighterStats> fighterStats;
    [SerializeField]
    private GameObject battleMenu;

    public Text battleText;
    public GameObject player ;
    public GameObject enemy ;
    void Start()
    {
        MusicManager.Instance.EnterEncounterHandler();
        fighterStats = new List<FighterStats>();
       
        FighterStats currentFighterStats = player.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

     
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);
        fighterStats.Sort();
        battleMenu.SetActive(false);
        NextTurn();
    }

    public void NextTurn()
    {
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "Player")
            {
                battleMenu.SetActive(true);
            } else if(currentUnit.tag == "Enemy")
            {
                battleMenu.SetActive(false);
                string attackType = Random.Range(0, 2) == 1 ? "hack" : "magic";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            if(currentUnit.tag == "Dead")
            {
                if (player.tag == "Dead")
                {
                    StartCoroutine(YouLost());
                }
                else if(enemy.tag == "Dead")
                {
                    StartCoroutine(YouWin());
          
                }
            }
        }
    }

    IEnumerator YouWin()
    {
        GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GetComponent<GameController>().battleText.text = "You Win！";
        yield return new WaitForSeconds(3.0f);
  
        SceneManager.LoadScene("TestScene");
    }
    IEnumerator YouLost()
    {
        GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GetComponent<GameController>().battleText.text = "You Lost！";
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("GameOver");
    }
}