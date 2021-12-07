using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EncounterInstance : MonoBehaviour
{
   // private int turnNumber = 0;

   /* public int TurnNumber
    { get{return turnNumber;}
    private*/

    //public List<ICharacter> combatants;

    private bool playerTurn;
    private float AiTurnTime = 0;
   
    public PlayerCharacter player = null;
    public AICharacter enemy = null;

    private AttackScript soundclip;
    /*public ICharacter currentCharacter;

    public UnityEvent<PlayerCharacter> onPlayerTurnBegin;
    public UnityEvent<PlayerCharacter> onPlayerTurnEnd;
    public UnityEvent<AICharacter> onEnemyTurnBegin;
    public UnityEvent<AICharacter> onEnemyTurnEnd;
    public UnityEvent<ICharacter> onTurnBegin;
    public UnityEvent<ICharacter> onTurnEnd;*/

    // Start is called before the first frame update
    
    public bool Turn
    { 
        get
        {
            return playerTurn;
        }

        set
        {
            playerTurn = value;
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AICharacter>();
        playerTurn = true;
    }
    
   /* public void AdvanceTurns()
    {   
        onTurnEnd.Invoke(currentCharacter);
        if (currentCharacter == player)
        {
           
            currentCharacter = enemy;
            onPlayerTurnEnd.Invoke(player);
           player.onAbilityCast.RemoveListener(OnAbilityCastCallback);
            enemy.onAbilityCast.AddListener(OnAbilityCastCallback);
            onEnemyTurnBegin.Invoke((enemy));
        }
        else
        {
            currentCharacter = player;
            //onTurnBegin.Invoke(player);
          enemy.onAbilityCast.RemoveListener(OnAbilityCastCallback);
           player.onAbilityCast.AddListener(OnAbilityCastCallback);
           onEnemyTurnEnd.Invoke(enemy);
           onPlayerTurnBegin.Invoke(player);
        }
        turnNumber++;
        onTurnBegin.Invoke(currentCharacter);
        currentCharacter.TakeTurn(this);
    }*/
   private void Update()
   {
       // AI Turn
       if (!playerTurn)
       {
           AiTurnTime += Time.deltaTime;

           if (AiTurnTime >= 3.0f)
           {
               AiTurnTime = 0.0f;

               // AI Ability
               int AIAbility = Random.RandomRange(0, 3);

               AICharacter CurrentEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AICharacter>();
               Ability EnemyAbility = null;

               // Set AI SkillSet
               if (CurrentEnemy)
               {
                   EnemyAbility = CurrentEnemy.GetAbility(AIAbility);
               }

               // Use ability
               ApplyEffect(EnemyAbility, false);

               Debug.Log("AI Ability : " + AIAbility);

               // Change turns
               playerTurn = true;
           }
       }
   }
   // Player Abilities
    public void Ability1()
    {
        if (!playerTurn)
            return;
        
        playerTurn = false;

        // Use ability
        ApplyEffect(player.Abilities[0], true);
    }
    public void Ability2()
    {
        if (!playerTurn)
            return;

        // Play button sound
       // soundManager.PlaySound(SoundManager.TrackID.BUTTON);

        playerTurn = false;

        // Use ability
        ApplyEffect(player.Abilities[1], true);
    }
    public void Ability3()
    {
        if (!playerTurn)
            return;

        // Play button sound
      //  soundManager.PlaySound(SoundManager.TrackID.BUTTON);

        playerTurn = false;

        // Use ability
        ApplyEffect(player.Abilities[2], true);
    }
    
    private void ApplyEffect(Ability ability, bool isPlayer)
    {

   
        ICharacter currentCharacter = null;
        if (isPlayer)
        {
            currentCharacter = enemy;
        }
        else
        {
            currentCharacter  = player;
        }
    }

    IEnumerator WinOrLose(ICharacter loser)
    {
        
        if (loser == enemy)
        {
        //    EncounterUI.SetText("Enemy is defeated... you win!!!!!!!! YAY!");

        }
        else
        {
       //     EncounterUI.SetText("You lost... you feel a bit more cursed.");
            
        }
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("GameOver");

    }
}
