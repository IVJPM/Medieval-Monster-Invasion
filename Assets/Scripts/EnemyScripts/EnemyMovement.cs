using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Animator animator;
    AnimationClip currentAnimation;
    Rigidbody enemyRB;
    NavMeshAgent navMeshAgent;

    [SerializeField] AnimationClip chasingAnimation;
    [SerializeField] float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    public void ChasePlayerTarget(GameObject playerTarget, float chaseSpeedValue)
    {
        //Setting the NavMesh acceleration to 50 and turning speed to 360 has somehow helped stop enemies at the right spot (mess around with speed later if desired)

        Vector3 newPosition = playerTarget.transform.position;
        newPosition.y = transform.position.y;

        Quaternion enemyLookDirection;
        Quaternion lookDirection = Quaternion.Euler(navMeshAgent.velocity);

        enemyLookDirection = Quaternion.RotateTowards(lookDirection, navMeshAgent.transform.rotation, 720);

        enemyRB.MoveRotation(enemyLookDirection);
        navMeshAgent.speed = chaseSpeedValue;
        navMeshAgent.destination = (playerTarget.transform.position);
    }

    public void SetEnemyMovementAnimation()
    {
        AnimationsManager.instance.PlayAnimation(animator, chasingAnimation, .25f);
    }
}
