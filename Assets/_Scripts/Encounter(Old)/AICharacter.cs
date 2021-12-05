using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AICharacter : ICharacter
{
    public int maxHP;
    public int currentHP;
    public int MP;
    public Ability[] EnemyAbility;

    public Ability GetAbility(int Index)
    {
        return EnemyAbility[Index];
    }

    void Start()
    {
        // Find Ability Manger
        AbilitiesMenu[] Skill = FindObjectsOfType<AbilitiesMenu>();

        AbilitiesMenu SKL = null;

        // If there's Ability Manager
        if (Skill.Length >= 1)
        {
            SKL = Skill[0];
        }

        if (SKL)
        {
           
            EnemyAbility = new Ability[2];

            int[] AbilityIndex = new int[5];

            for (int i = 0; i < 5; ++i)
            {
                AbilityIndex[i] = i;
            }

           
            for (int i = 0; i < 100; ++i)
            {
                int idx1 = Random.RandomRange(0, 5);
                int idx2 = Random.RandomRange(0, 5);

                int temp = AbilityIndex[idx1];
                AbilityIndex[idx1] = AbilityIndex[idx2];
                AbilityIndex[idx2] = temp;
            }


            EnemyAbility[0] = SKL.FindAbility(AbilityIndex[2]);
            EnemyAbility[1] = SKL.FindAbility(AbilityIndex[3]);
           
        }
    }
}
