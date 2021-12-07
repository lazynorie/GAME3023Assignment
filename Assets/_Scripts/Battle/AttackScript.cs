using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class AttackScript : MonoBehaviour
{
   public GameObject owner;
   [SerializeField]
   private string animationName;
   [SerializeField] private bool magicAttack;
   [SerializeField] private float  magicCost;
   [SerializeField] private float minAttackMultiplier;
   [SerializeField] private float maxAttackMultiplier;
   [SerializeField] private float minDefenseMultiplier;
   [SerializeField] private float maxDefenseMultiplier;

   private FighterStats attackerStates;
   private FighterStats targetStats;
   private float damage = 0.0f;
   private float xMagicNewScale;
   private Vector2 magicScale;

   
   
   
  private void Start()
   {
      
      magicScale = GameObject.Find("PlayerMPFill").GetComponent<RectTransform>().localScale;
   }

 
  public void Attack(GameObject victim)
   {
      attackerStates = owner.GetComponent<FighterStats>();
      targetStats = victim.GetComponent<FighterStats>();
      
         if (attackerStates.magic >= magicCost)
      {
         float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
    
         damage = multiplier * attackerStates.hack;
     
         attackerStates.updateManaFill(magicCost);
         if (magicAttack)
         {
            damage = multiplier * attackerStates.fireball;
           // attackerStates.magic -= magicCost;
         }
         float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            
         damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
         owner.GetComponent<Animator>().Play(animationName);
         targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
      }
      
   }
   
}
