using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "AbilitySystem/Ability")]
public class Ability : ScriptableObject
{
   public new string name;
   public IEffect[] effects;
   public string description;


   public void Cast(ICharacter self, ICharacter other)
   
   {
      Debug.Log("Cast" + name);
      foreach (IEffect effect in effects)
      {
        
         effect.ApplyEffect(self, other);
       
      }

      self.onAbilityCast.Invoke(this);
   }
}
