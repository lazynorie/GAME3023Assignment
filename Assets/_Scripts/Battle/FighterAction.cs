using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
   private GameObject enemy;
   private GameObject player;

   [SerializeField] private GameObject attackPrefab;
   [SerializeField] private GameObject magicPrefab;
  // [SerializeField] private Sprite faceIcon;

   private GameObject currentAttack;
   //private GameObject hack;private GameObject magic;

    void Awake()
   {
      player = GameObject.FindGameObjectWithTag("Player");
      enemy = GameObject.FindGameObjectWithTag("Enemy");
   }

   public void SelectAttack(string btn)
   {
   
      GameObject victim = player;
      if (tag == "Player")
      {
         //currentAttack = hack;
         victim = enemy;
      }

      if (btn.CompareTo("hack") == 0)
      {
         attackPrefab.GetComponent<AttackScript>().Attack(victim);
         Debug.Log("Attack!!!");
      }
      else if (btn.CompareTo("magic") == 0)
      {
         magicPrefab.GetComponent<AttackScript>().Attack(victim);
         Debug.Log("Magic!!!");
      }

   }
}
