using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : ICharacter
{
  /*  [SerializeField]
    private EncounterInstance myEncounter;*/
  public int HP { get; set; }

  
  public int maxHP
  {
      get { return maxHP; }
  }

  public int MP
  {
      get { return MP; }
  }

  public Ability[] PlayerAbility;
    public Ability[] Abilities
    {
        get
        {
            return PlayerAbility;
        }
    }

}