using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdolState : PlayerBaseState
{
  

    public override void EnterState(PlayerStateManager player)
    {
       
    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        // Add any additional fixed update logic if needed
    }



    public override void OnTriggerEnter2D(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }
}
