using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    [SerializeField] AnimationClip idleAnimation;
    [SerializeField] Animator playerAnimation;


    public override void EnterState()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimation, idleAnimation, .01f);

    }

    public override void ExitState()
    {
        
    }

    public override void RunState(GameObject character)
    {
        
    }
}
