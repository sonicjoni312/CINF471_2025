using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm walking!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //What are we doing in this state?
        player.MovePlayer(player.default_speed);

        //When are we leaving this state?
        if(player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.IdleState);
        } else if (player.isSneaking)
        {
            player.SwitchState(player.sneakState);
        }

    }
}
