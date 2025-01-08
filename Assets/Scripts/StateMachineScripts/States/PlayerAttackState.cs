using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : CharacterState
{
    public override void EnterState()
    {
        //AnimationsManager.instance.PlayAnimation(playerAnimation, runningAnimation, .1f);
    }

    public override void ExitState()
    {

    }

    public override void RunState(GameObject player)
    {
        if (this.enabled == true)
        {
            player.TryGetComponent(out ShootBow playerShootBow);
            playerShootBow.DrawBow();
            playerShootBow.BowShot();
        }
    }
}
