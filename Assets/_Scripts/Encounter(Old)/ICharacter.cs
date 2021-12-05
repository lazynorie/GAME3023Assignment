using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ICharacter : MonoBehaviour
{
    [SerializeField]
    protected Ability[] abilities;
    private EncounterInstance encounter;
    public UnityEvent<Ability> onAbilityCast;
   /* public void CastAbility(int abilitySlot, ICharacter self, ICharacter enemy)
    {
        abilities[abilitySlot].Cast(self,enemy);
    }

    public abstract void TakeTurn(EncounterInstance encounter);*/
    
}
