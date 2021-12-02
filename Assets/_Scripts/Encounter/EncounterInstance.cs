using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EncounterInstance : MonoBehaviour
{
    
    
    
    private int turnNumber;

    public int TurnNumber
    { get{return turnNumber;}
    private set{turnNumber = value;}
}

    public PlayerCharacter player;
    public AICharacter enemy;
    public ICharacter currentCharacter;

    public UnityEvent<PlayerCharacter> onPlayerTurnBegin;
    public UnityEvent<PlayerCharacter> onPlayerTurnEnd;
    public UnityEvent<AICharacter> onEnemyTurnBegin;
    public UnityEvent<ICharacter> onTurnBegin;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = player;
        player.onAbilityCast.AddListener(OnAbilityCastCallback);
        
        //BGM
        MusicManager.Instance.PlayTrack(MusicManager.TrackID.Battle);
    }

    public void OnAbilityCastCallback(Ability casted)
    {
        AdvanceTurns();
    }

    public void AdvanceTurns()
    {   turnNumber++;
        if (currentCharacter == player)
        {
            currentCharacter = enemy;
            player.onAbilityCast.RemoveListener(OnAbilityCastCallback);
            enemy.onAbilityCast.AddListener(OnAbilityCastCallback);
            onPlayerTurnEnd.Invoke(player);
            onEnemyTurnBegin.Invoke((enemy));
        }
        else
        {
            currentCharacter = player;
            enemy.onAbilityCast.RemoveListener(OnAbilityCastCallback);
            player.onAbilityCast.AddListener(OnAbilityCastCallback);
            onPlayerTurnBegin.Invoke(player);
        }
        onTurnBegin.Invoke(currentCharacter);
        currentCharacter.TakeTurn(this);
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("TestScene");            
    }

    
}
