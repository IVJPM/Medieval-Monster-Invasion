using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] AnimationClip attackAnimation;
    
    GameObject playerTarget;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindWithTag("Player");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //AttackPlayer();
    }

    private void AttackPlayer()
    {
        if(Vector3.Distance(transform.position, playerTarget.transform.position) <= 2.5f)
        {
            AnimationsManager.instance.PlayAnimation(animator, attackAnimation, .1f);
        }
    }

    public void SetEnemyMovementAnimation()
    {
        AnimationsManager.instance.PlayAnimation(animator, attackAnimation, .25f);
    }
}
