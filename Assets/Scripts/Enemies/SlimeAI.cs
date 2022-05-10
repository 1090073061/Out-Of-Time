using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SlimeAI : EnemyAI
{
    //I do not have time to give the slime a unique animation, so this will be a mirror of the EnemyAI script
    /*
    void Attack()
    {
        if (attackCooldown <= 0f)
        {
            //Perform attack here
            //I plan to make the enemy stop and jump at the player to attack them


            attackCooldown = attackSpeed;
        }
    }
    */
}
