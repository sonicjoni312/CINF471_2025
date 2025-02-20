using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm idling!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.movement.magnitude > 0.1)
        {
            player.SwitchState(player.walkState);
            if(player.isSneaking)
        {
            player.SwitchState(player.sneakState);
        }
        }
        

    }

}
