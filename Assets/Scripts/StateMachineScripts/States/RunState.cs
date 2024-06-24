using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    [SerializeField] AttackState attackState;

    GameObject playerTarget;

    [SerializeField] Animator animator;
    [SerializeField] AnimationClip chasingAnimation;
    [SerializeField] float speed;


    private void Start()
    {
        playerTarget = GameObject.FindWithTag("Player");
    }
    public override State RunCurrentState()
    {
        if (Vector3.Distance(transform.position, playerTarget.transform.position) <= 2.5f)
        {
            return attackState;
        }
        else
        {
            transform.position -= (transform.position - playerTarget.transform.position).normalized * speed * Time.deltaTime;

            AnimationsManager.instance.PlayAnimation(animator, chasingAnimation, .1f);
            return this;
        }
    }
}
