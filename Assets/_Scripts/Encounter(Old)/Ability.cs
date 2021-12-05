using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "AbilitySystem/Ability")]
public class Ability : ScriptableObject
{
   public new string name;
   public string description;
   public IEffect[] effects;
  


   public new string AbilityName
   {
      get
      {
         return name;
      }
   }
   public string Desc
   {
      get
      {
         return description;
      }
   }
  /* public int Damage
   {
      get
      {
         return damage;
      }
   }*/
}
