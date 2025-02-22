using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //GameObject playerTarget;
    Animator animator;
    AnimationClip currentAnimation;
    Rigidbody enemyRB;
    NavMeshAgent navMeshAgent;

    [SerializeField] AnimationClip chasingAnimation;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        //playerTarget = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(navMeshAgent.destination, new Vector3(navMeshAgent.destination.x, navMeshAgent.destination.y + 1f, navMeshAgent.destination.z), Color.red);
        print(navMeshAgent.transform.position);

        //ChasePlayerTarget();
    }

    public void ChasePlayerTarget(GameObject playerTarget, float chaseSpeedValue)
    {
        Vector3 newPosition = playerTarget.transform.position;
        newPosition.y = transform.position.y;
        transform.LookAt(newPosition);
        navMeshAgent.speed = chaseSpeedValue;
        navMeshAgent.destination = (playerTarget.transform.position); 
        //transform.position -= (transform.position - playerTarget.transform.position).normalized * chaseSpeedValue * Time.deltaTime;
    }

    public void SetEnemyMovementAnimation()
    {
        AnimationsManager.instance.PlayAnimation(animator, chasingAnimation, .25f);
    }
}
