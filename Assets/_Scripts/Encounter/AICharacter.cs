using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : ICharacter
{
    
    public override void TakeTurn(EncounterInstance encounter)
    { Debug.Log("ai Turn!");
     //  encounter.AdvanceTurns();
     CastAbility(Random.Range(0,abilities.Length),this,encounter.player);
    }
}
