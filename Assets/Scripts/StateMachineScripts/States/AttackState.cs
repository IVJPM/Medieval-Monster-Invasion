using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] RunState runState;

    GameObject playerTarget;

    [SerializeField] Animator animator;
    [SerializeField] AnimationClip attackAnimation;


    private void Start()
    {
        playerTarget = GameObject.FindWithTag("Player");
    }
    public override State RunCurrentState()
    {
        if (Vector3.Distance(transform.position, playerTarget.transform.position) > 2.5f)
        {
            transform.position -= (transform.position - playerTarget.transform.position).normalized * 1 * Time.deltaTime;

            AnimationsManager.instance.PlayAnimation(animator, attackAnimation, .25f);
            return runState;
        }
        else
        {
            return this;
        }
    }
}
