using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
  public  PlayerWalkingState PlayerWalkingStateRR;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("attack statess");
      
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
  
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
   
    }

 

    public override void UpdateState(PlayerStateManager player)
    {
        
    }


}
