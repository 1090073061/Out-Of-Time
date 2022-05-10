using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Base code for a walking enemy
 */
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent navAgent;

    public float alertRadius = 10f;
    public bool isAlert = false;
    public bool inProximity = false;

    public float attackSpeed = 1f; //Fixed variable for time between attacks
    [HideInInspector] public float attackCooldown = 0f; //Tracks how many seconds are left until next attack
    public Transform attackPoint;
    public float attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //If this produces lag, we can reduce that by having a singleton pass the variable to all enemy AIs
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (isAlert)
        {
            navAgent.SetDestination(target.position);
            if (distance <= navAgent.stoppingDistance)
            {
                Attack();
                //Face Target
                Vector3 direction = (target.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
        else if (distance <= alertRadius)
        {
            Alert();
        }

        attackCooldown -= Time.deltaTime;
    }

    void FixedUpdate()
    {

    }

    void Alert()
    {
        //Test if anything is between enemy and player. Fires a ray that ignores all entities
        Vector3 dir = (target.position - transform.position).normalized;
        float maxDist = Vector3.Distance(transform.position, target.position);
        int layerMask = LayerMask.GetMask("Entity"); //Add name of any future layers that don't block line of sight as additional string argument, or make public LayerMask variable
        layerMask = ~layerMask; //Inverts mask
        if (!Physics.Raycast(transform.position, dir, maxDist, layerMask))
        {
            isAlert = true;
        }
    }

    void Attack()
    {
        if (attackCooldown <= 0f)
        {
            //Perform attack here
            //Attack animation here
            Collider[] hitCol = Physics.OverlapSphere(attackPoint.position, attackRange, LayerMask.GetMask("Entity")); //Layer mask may also be specified with public inspector var
            foreach(Collider entity in hitCol)
            {
                if(entity.gameObject.CompareTag("Player"))
                {
                    //Damage player here
                    inProximity = true;
                    Debug.Log("Player damaged");
                    break;
                }
            }

            attackCooldown = attackSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

