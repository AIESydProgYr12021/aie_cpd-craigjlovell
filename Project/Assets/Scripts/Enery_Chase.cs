using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enery_Chase : MonoBehaviour
{
    public NavMeshAgent myAgent;
    public Transform target;

    public int damage = 10;
    private player_health playerhealth;

    public float stoppingDistance = 3f;
    private float distanceFromTarget;

    public bool chaseTarget = true;

    public float delayBetweenAtt = 1.5f;
    private float attCooldown;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.stoppingDistance = stoppingDistance;
        attCooldown = Time.time;        
        playerhealth = GameObject.FindGameObjectWithTag ("player").GetComponent<player_health>();
    }

    void ChaseTarget()
    {

        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if(distanceFromTarget >= stoppingDistance)
        {
            chaseTarget = true;            
        }
        else
        {
            chaseTarget = false;
            Attack();
        }

        if(chaseTarget)
        {
            myAgent.SetDestination(target.position);
        }
    }
    
    void Update()
    {        
        ChaseTarget();
    }

    void Attack()
    {
        if (Time.time > attCooldown)
        {
            playerhealth.TakeDamage(damage);
            attCooldown = Time.time + delayBetweenAtt;
        }
    }
}
