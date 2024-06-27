using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isInAttackRange { get; private set; }

    EnemyMovement enemyMovement;
    EnemyAttacks enemyAttacks;
    GameObject playerTarget;


    [SerializeField] float stateTransitionTimer;
    [SerializeField] float chaseTargetSpeed;

    public enum State // Will update to a more advanced version if enough additional states are needed in the future. For now, this will work :)
    {
        ChasePlayer,
        Attack
    };
    State currentState;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttacks = GetComponent<EnemyAttacks>();

        playerTarget = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerTarget.transform.position) > 1.25f)
        {
            isInAttackRange = false;
        }
        else
        {
            isInAttackRange = true;
        }

        ChangeStates();
    }

    private void ChangeStates()
    {
        switch (currentState)
        {
            case State.ChasePlayer:
            {
               enemyMovement.ChasePlayerTarget(playerTarget, chaseTargetSpeed);

              if (isInAttackRange == true)
              {
                    stateTransitionTimer = 0;
                    currentState = State.Attack;
                    enemyAttacks.SetEnemyMovementAnimation();
              }
            }
            break;
            case State.Attack:
            {
                stateTransitionTimer += Time.deltaTime;

                if (isInAttackRange == false && stateTransitionTimer >= 1.75f)
                {
                     currentState = State.ChasePlayer;
                     enemyMovement.SetEnemyMovementAnimation();
                }
            }
            break;
        }
    }

}
