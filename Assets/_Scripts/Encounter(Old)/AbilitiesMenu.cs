using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesMenu : MonoBehaviour
{
   public Ability[] AbilityArray;
   
   public Ability FindAbility(string Name)
   {
      for (int i = 0; i < AbilityArray.Length; ++i)
      {
         if (AbilityArray[i].AbilityName == Name)
            return AbilityArray[i];
      }
      return null;
   }

   public Ability FindAbility(int Index)
   {
      return AbilityArray[Index];
   }

   void Start()
   {
      DontDestroyOnLoad(gameObject);

      AbilitiesMenu[] imposters = FindObjectsOfType<AbilitiesMenu>();

      if (imposters.Length > 1)
      {
         foreach (AbilitiesMenu imposter in imposters)
         {
            if (imposter == this)
            {
               Destroy(imposter.gameObject);
               break;
            }
         }
      }
   }


}
