using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdolState : PlayerBaseState
{
    private Vector2 moveInput;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("This is IdolState");
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
       
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (moveInput != Vector2.zero)
        {
            player.SwitchState(player.walkingState);
        }
    }

  
}
