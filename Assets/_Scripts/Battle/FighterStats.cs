using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [SerializeField]
    private GameObject magicFill;

    [SerializeField] private GameObject Info;

    [SerializeField] 
    [Range(0,100)]
    private int Run;
    
    [SerializeField] 
    [Range(0,100)]
    private int struggle;
    //[SerializeField] private Text battleText;
    [Header("Stats")]
    public float health;
    public float magic;
    public float hack;
    public float fireball;
    public float defense;
    public float speed;
    public float experience;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool dead = false;

    // Resize health and magic bar
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private GameObject GameControllerObj;

    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;

        startHealth = health;
        startMagic = magic;

        GameControllerObj = GameObject.Find("GameControllerObject");

    }

    public void ReceiveDamage(float damage)
    {
        health = health - damage;
        animator.Play("Hit");

        // Set damage text

        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Info.SetActive(false);
            gameObject.SetActive(false);
 
        } else if (damage > 0)
        {
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
        if(damage > 0)
        {
          GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
          GameControllerObj.GetComponent<GameController>().battleText.text = gameObject.tag +" have taken  : "+ damage.ToString() + " of Damage";
        }
        Invoke("ContinueGame", 2);
    }
    public void updateManaFill(float cost)
    {
        if(cost > 0)
        {
            magic = magic - cost;
            xNewMagicScale = magicScale.x * (magic / startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
        }
    }
    public void OnStruggleButtonPressed()
    {
        if (Random.Range(1, 101) <= struggle)
        {
        
            StartCoroutine(Struggle());

        }
        else
        {
            StartCoroutine(FailedStruggle());
        }

    }
    
    public void OnExitButtonPressed()
    {
        if (Random.Range(1, 101) <= Run)
        {
        
            StartCoroutine(Escape());

        }
        else
        {
            StartCoroutine(Failedescape());
        }

    }

    IEnumerator Escape()
    {
        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = "Escape Success???";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("TestScene");
    }
    IEnumerator Failedescape()
    {
        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = "Failed Escape???";
        yield return new WaitForSeconds(1.0f);
        GameControllerObj.GetComponent<GameController>().NextTurn();
    }
    IEnumerator Struggle()
    {
        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = "Struggle Success???";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("TestScene");
    }
    IEnumerator FailedStruggle()
    {
        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = "Failed Struggle???";
        yield return new WaitForSeconds(1.0f);
        GameControllerObj.GetComponent<GameController>().NextTurn();
    }
    public bool GetDead()
    {
        return dead;
    }

  void ContinueGame()
    {
       GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
   public void CalculateNextTurn(int currentTurn)
    {
        nextActTurn = currentTurn + Mathf.CeilToInt(100f / speed);
    }

    public int CompareTo(object otherStats)
    {
        int nex = nextActTurn.CompareTo(((FighterStats)otherStats).nextActTurn);
        return nex;
    }

}
