using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEffect : ScriptableObject
{
   public abstract void ApplyEffect(ICharacter self, ICharacter other);
}
