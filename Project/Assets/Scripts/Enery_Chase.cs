using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Enery_Chase : MonoBehaviour
{
    private Animation animation;
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
        animation = GetComponent<Animation>();
        animation.Play("Walk");

        myAgent = GetComponent<NavMeshAgent>();
        myAgent.stoppingDistance = stoppingDistance;
        attCooldown = Time.time;        
        playerhealth = GameObject.FindGameObjectWithTag("player").GetComponent<player_health>();
    }

    void ChaseTarget()
    {

        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        if(distanceFromTarget >= stoppingDistance)
        {
            chaseTarget = true;
            animation.Play("Walk");
        }
        else
        {
            chaseTarget = false;            
            Attack();
            animation.Play("Attack1");
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
