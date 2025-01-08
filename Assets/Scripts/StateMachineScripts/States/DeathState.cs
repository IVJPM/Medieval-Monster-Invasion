using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : CharacterState
{
    [SerializeField] AnimationClip deathAnimation;
    [SerializeField] Animator playerAnimation;
    public override void EnterState()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimation, deathAnimation, .1f);
    }

    public override void ExitState()
    {

    }

    public override void RunState(GameObject character)
    {
        character.GetComponentInChildren<PlayerMovement>().enabled = false;
    }
}
